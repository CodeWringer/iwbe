using Iwbe.Domain.Model;

namespace Iwbe.Domain.Provider
{
    public interface IProjectProvider
    {
        /// <summary>
        /// Returns a project, loaded from the given location. 
        /// </summary>
        /// <param name="path">Full file path identifying a project. </param>
        /// <returns></returns>
        Project Load(string path);

        /// <summary>
        /// Writes the given project to disk. 
        /// </summary>
        /// <param name="project">The project to write to disk. </param>
        /// <returns></returns>
        void Write(Project project);
    }
}