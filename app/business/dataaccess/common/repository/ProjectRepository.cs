using iwbe.business.dataaccess.common.datasource;
using iwbe.business.dataaccess.dto;
using iwbe.business.dataaccess.util;
using iwbe.business.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace iwbe.business.dataaccess.common.repository
{
    internal class ProjectRepository : IReadableRepository<List<Project>>, IWriteableRepository<Project>
    {
        private bool _mock;

        public ProjectRepository(bool mock)
        {
            _mock = mock;
        }

        public List<Project> Read()
        {
            if (_mock)
            {
                var list = new List<Project>
                {
                    new Project(
                        "Project A",
                        new Guid(),
                        "user://path/to/project/a/project.json",
                        new DateTime(2023, 12, 24),
                        new DateTime(2023, 12, 24, 13, 10, 20)
                    ),
                    new Project(
                        "Project B",
                        new Guid(),
                        "user://path/to/project/b/project.json",
                        new DateTime(2023, 12, 24),
                        new DateTime(2023, 12, 24, 13, 10, 20)
                    ),
                    new Project(
                        "Project C",
                        new Guid(),
                        "user://path/to/project/c/project.json",
                        new DateTime(2023, 12, 24),
                        new DateTime(2023, 12, 24, 13, 10, 20)
                    )
                };

                return list;
            } else {
                var projectIdFiles = new List<string>();

                string userDirPath = PathUtility.GetUserDirPath();
                var directories = Directory.EnumerateDirectories(userDirPath);
                foreach (var directory in directories)
                {
                    string projectIdPath = Path.Combine(directory, "project.json");
                    if (File.Exists(projectIdPath)) {
                        projectIdFiles.Add(projectIdPath);
                    }
                }

                var projects = new List<Project>();
                foreach (var projectIdFile in projectIdFiles)
                {
                    using (Stream stream = new FileStream(projectIdFile, FileMode.Open))
                    {
                        var dto = JsonSerializer.Deserialize<ProjectDto>(stream);
                        projects.Add(Project.FromDto(dto));
                    }
                }

                return projects;
            }
        }

        public void Write(Project toWrite)
        {
            JsonSerializer.Serialize(toWrite.ToDto());
        }
    }
}
