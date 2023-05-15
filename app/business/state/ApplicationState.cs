using System.Collections.Generic;
using Godot;
using System;
using System.IO;
using iwbe.business.model;
using iwbe.business.exception;
using iwbe.business.dataaccess.applicationsettings;
using iwbe.business.util.watchable;
using iwbe.business.actionhistory.command;
using iwbe.business.command;

namespace iwbe.business.state
{
    /// <summary>
    /// This is the base and global application state object. 
    /// <br></br>
    /// It contains all root-level business data. 
    /// </summary>
    public partial class ApplicationState : AbstractApplicationState<ApplicationState>, IWatchable
    {
        public event WatchableChangeHandler Changed;

        /// <summary>
        /// Global application settings. 
        /// </summary>
        public Watchable<ApplicationSettings> Settings { get; private set; } = new();

        /// <summary>
        /// The currently loaded project. 
        /// </summary>
        public Watchable<Project> Project { get; private set; } = new();

        /// <summary>
        /// Represents the "undo-history", applicable to the <b>currently loaded project</b>. 
        /// </summary>
        public CommandHistory UndoHistory { get; private set; } = new();

        /// <summary>
        /// Central point of communication of commands that alter application state in any way. 
        /// </summary>
        public CommandDispatcher CommandDispatcher { get; private set; } = new();

        public ApplicationState()
        {
            // Load settings from disk, if possible. Else, instantiate default settings. 
            var repository = new ApplicationSettingsRepository();
            try
            {
                Settings .Value= repository.Read();
            }
            catch (FileNotFoundException)
            {
                Settings.Value = new ApplicationSettings();
                repository.Write(Settings.Value);
            }

            Settings.Changed += ChildWatchable_Changed;
            Project.Changed += ChildWatchable_Changed;
        }

        /// <summary>
        /// Returns the ApplicationState from the ApplicationStateNode in the scene tree. 
        /// <br></br>
        /// Requires an instance of a node that is currently in the scene tree to work. 
        /// </summary>
        /// <param name="nodeInSceneTree">Instance of a node that is currently in the scene tree. </param>
        /// <exception cref="MissingNodeException">Thrown, if the ApplicationStateNode could not be fetched. </exception>
        /// <returns>The global application state. </returns>
        public static ApplicationState GetFromSceneTree(Node nodeInSceneTree)
        {
            var node = nodeInSceneTree.GetTree().Root.GetNode<ApplicationStateNode>("ApplicationStateNode");
            if (node == null)
                throw new MissingNodeException();
            else 
                return node.State;
        }

        public override void Apply(ApplicationState toApply)
        {
            this.Settings = toApply.Settings;
        }

        public override ApplicationState Clone()
        {
            var clone = new ApplicationState();
            clone.Settings.Value = clone.Settings.Value.Clone();

            return clone;
        }

        /// <summary>
        /// Passes through child watchable Changed event invocations. 
        /// </summary>
        /// <param name="args"></param>
        private void ChildWatchable_Changed(WatchableChangedEventArgs args)
        {
            Changed?.Invoke(args);
        }
    }
}
