using iwbe.business.dataaccess.util;
using System;
using System.IO;
using Utf8Json;

namespace iwbe.business.dataaccess.common.datasource
{
    /// <summary>
    /// Represents a file system data source, using the OS's absolute paths. 
    /// <br></br>
    /// Writes the data out as json and parses from json. 
    /// </summary>
    /// <typeparam name="T">The type of data to read/write. </typeparam>
    internal class FileSystemDataSource<T> : AbstractReadWriteDataSource<T>
    {
        /// <summary>
        /// Returns the absolute file path, using OS's absolute paths. 
        /// </summary>
        public string FilePath { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">The file path. </param>
        /// <exception cref="ArgumentException">Thrown if the given file path is in an invalid format. </exception>
        public FileSystemDataSource(string filePath)
        {
            if (PathUtility.IsFilePathValid(filePath) != true)
                throw new ArgumentException("File path format invalid", nameof(FilePath));

            FilePath = filePath;
        }

        /// <summary>
        /// Reads data from the file system, using Godot's relative paths and returns an instance of type T parsed from the file contents. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException">Thrown, if the file does not exist. </exception>
        public override T Read()
        {
            if (Godot.FileAccess.FileExists(FilePath) != true)
                throw new FileNotFoundException();

            using (var file = Godot.FileAccess.Open(FilePath, Godot.FileAccess.ModeFlags.Read))
            {
                string content = string.Empty;
                content = file.GetAsText();
                return JsonSerializer.Deserialize<T>(content);
            }
        }

        /// <summary>
        /// Writes the given instance of type T to the user directory. 
        /// </summary>
        /// <param name="toWrite">The instance to write out. </param>
        public override void Write(T toWrite)
        {
            using (var file = Godot.FileAccess.Open(FilePath, Godot.FileAccess.ModeFlags.Write))
            {
                string content = JsonSerializer.ToJsonString(toWrite);
                file.StoreString(content);
            }
        }
    }
}
