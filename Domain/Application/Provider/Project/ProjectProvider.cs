using Iwbe.Domain.Model;
using System;

namespace Iwbe.Domain.Provider
{
    public class ProjectProvider : IProjectProvider
    {
        public ProjectProvider()
        {
        }

        public Project Load(string path)
        {
            throw new NotImplementedException();
        }

        public void Write(Project project)
        {
            throw new NotImplementedException();
        }
    }
}