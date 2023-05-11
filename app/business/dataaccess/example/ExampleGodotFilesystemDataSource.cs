using iwbe.business.dataaccess.common.datasource;
using iwbe.business.dataaccess.example.dto;
using iwbe.business.dataaccess.util;

namespace iwbe.business.dataaccess.example
{
    internal class ExampleGodotFileSystemDataSource : GodotFileSystemDataSource<ExampleSerializable>
    {
        public ExampleGodotFileSystemDataSource()
            : base(PathUtility.USER_DIR_PATH_PREFIX + "example.json")
        {
        }
    }
}
