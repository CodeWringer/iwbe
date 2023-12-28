using System.Collections.Generic;
using Godot;
using System;
using System.IO;
using iwbe.business.model;
using iwbe.business.exception;
using iwbe.business.dataaccess.applicationsettings;
using iwbe.common.observables;
using iwbe.business.dataaccess.common.repository;

namespace iwbe.business.state
{
    /// <summary>
    /// This is the base and global application state object. 
    /// <br></br>
    /// It contains all root-level business data. 
    /// </summary>
    public partial class ApplicationState : AbstractApplicationState<ApplicationState>
    {
        /// <summary>
        /// General application settings. 
        /// </summary>
        public ApplicationSettings Settings { get; private set; }

        /// <summary>
        /// Determines whether the application runs in mock mode. 
        /// </summary>
        public bool Mock { get; private set; } = true; // TODO: Make dynamic

        /// <summary>
        /// If not null, the currently active project. 
        /// </summary>
        public ObservableData<Project> Project { get; private set; } = new();

        /// <summary>
        /// The list of project ids. 
        /// </summary>
        public ObservableDataCollection<ProjectId> ProjectIds { get; private set; } = new();

        public ApplicationState()
        {
            var repository = new ApplicationSettingsRepository();
            try
            {
                Settings = repository.Read();
            }
            catch (FileNotFoundException)
            {
                Settings = new ApplicationSettings();
                repository.Write(Settings);
            }

            try
            {
                var projects = new ProjectRepository(Mock).Read();
                var projectIds = new List<ObservableData<ProjectId>>();
                foreach (var project in projects)
                {
                    var observable = new ObservableData<ProjectId>
                    {
                        Value = project.ID
                    };
                    projectIds.Add(observable);
                }

                ProjectIds.AddRange(projectIds);
            }
            catch { }
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
            return new ApplicationState()
            {
                Settings = this.Settings.Clone()
            };
        }
    }
}
