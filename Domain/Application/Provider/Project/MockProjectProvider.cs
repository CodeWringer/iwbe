using Iwbe.Domain.Model;
using StoreSystem;
using System;
using System.Collections.Generic;

namespace Iwbe.Domain.Provider.Mock
{
    public class MockProjectProvider : IProjectProvider
    {
        public Project Load(string path)
        {
            return new Project(Guid.NewGuid(), System.IO.Path.GetFileNameWithoutExtension(path), path)
            {
                Assets = new ProjectAssets(),
                Content = new ProjectContent(),
                Generators = new ObservableList<ArticleGenerator>(),
                LastArticles = new ObservableList<string>(),
                LastWorkspace = "Writing",
                Templates = new ObservableList<ArticleTemplate>()
            };
        }

        public void Write(Project project)
        {
            IwbeApplication.LoggingProvider.Log("Pretending to write project to disk: " + project.Id.Name);
        }
    }
}