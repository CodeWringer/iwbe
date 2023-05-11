using iwbe.business.dataaccess.common.datasource;
using iwbe.business.dataaccess.common.repository;
using iwbe.business.state;

namespace iwbe.business.dataaccess.applicationsettings
{
    internal class ApplicationSettingsRepository : AbstractReadWriteRepository<ApplicationSettings>
    {
        public ApplicationSettingsRepository()
        {
            // TODO: Proper data source selection
            this.dataSource = new GodotFileSystemDataSource<ApplicationSettings>(ApplicationSettings.PATH_APP_SETTINGS);
        }
    }
}
