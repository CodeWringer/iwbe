using iwbe.business.dataaccess.common.datasource;
using iwbe.business.dataaccess.example.dto;
using iwbe.business.model;
using System.Collections.Generic;

namespace iwbe.business.dataaccess.example
{
    internal class ExampleGodotFileSystemMockDataSource : AbstractReadWriteDataSource<ExampleSerializable>
    {
        private ExampleSerializable data = new ExampleSerializable()
        {
            items = new List<AnItem>()
            {
                new AnItem("Abc1"),
                new AnItem("Def2"),
                new AnItem("Ghi3"),
            }
        };

        public override ExampleSerializable Read()
        {
            return data;
        }

        public override void Write(ExampleSerializable toWrite)
        {
            data = toWrite;
        }
    }
}
