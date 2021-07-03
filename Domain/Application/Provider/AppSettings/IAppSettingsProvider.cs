namespace Iwbe.Domain.Provider
{
    public interface IAppSettingsProvider
    {
        /// <summary>
        /// Loads the settings from disk, if possible. 
        /// </summary>
        /// <returns>AppSettings object, or null. </returns>
        AppSettings Load();

        /// <summary>
        /// Writes the given settings to disk. 
        /// </summary>
        /// <param name="settings"></param>
        void Write(AppSettings settings);
    }
}