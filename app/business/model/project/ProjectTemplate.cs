using System;
using System.Collections.Generic;

namespace iwbe.business.model
{
    /// <summary>
    /// Template for a project. 
    /// </summary>
    public class ProjectTemplate
    {
        /// <summary>
        /// Display name. 
        /// </summary>
        public string Name;

        /// <summary>
        /// UUID to identify the project, even if it is renamed. 
        /// </summary>
        public Guid ID;

        ///// <summary>
        ///// List of article templates specific to this project (not added to the global list of templates). 
        ///// </summary>
        //public List<ArticleTemplate> Templates;

        ///// <summary>
        ///// List of article generators specific to this project (not added to the global list of generators). 
        ///// </summary>
        //public List<ArticleGenerator> Generators;
    }
}