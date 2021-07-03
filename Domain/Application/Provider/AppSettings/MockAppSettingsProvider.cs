using Iwbe.Domain.Model;
using System;
using System.Collections.Generic;

namespace Iwbe.Domain.Provider.Mock
{
    public class MockAppSettingsProvider : IAppSettingsProvider
    {

        public MockAppSettingsProvider()
        {
        }

        public AppSettings Load()
        {
            IEnumerable<ProjectId> pinned = GetRandomProjectIds(8);
            IEnumerable<ProjectId> recent = GetRandomProjectIds(15);

            return new AppSettings()
            {
                PinnedProjects = pinned,
                RecentProjects = recent
            };
        }

        public void Write(AppSettings settings)
        {
            // Doesn't do anything.
        }

        private IEnumerable<ProjectId> GetRandomProjectIds(int howMany)
        {
            var rng = new Random();

            var result = new List<ProjectId>(howMany);
            for (int i = 0; i < howMany; i++)
            {
                var id = Guid.NewGuid();
                string idString = id.ToString();
                string shortId = idString.Substring(0, Math.Min(10, idString.Length));

                var newProjId = new ProjectId(
                    id,
                    "Project " + shortId,
                    "C:\\this\\is\\a\\long\\mock\\path\\Project " + shortId + "\\",
                    DateTime.Today - new TimeSpan(rng.Next(0, 20), 0, 0, 0),
                    DateTime.Today + new TimeSpan(rng.Next(0, 20), 0, 0, 0)
                );
                result.Add(newProjId);
            }

            return result;
        }
    }
}