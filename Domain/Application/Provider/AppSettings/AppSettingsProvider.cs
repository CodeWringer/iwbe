using Utf8Json;

namespace Iwbe.Domain.Provider
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        public string Path { get; private set; }

        public AppSettingsProvider()
        {
            Path = System.IO.Path.Combine(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, "ini.json");
        }

        public AppSettings Load()
        {
            if (System.IO.File.Exists(Path) != true)
                return null;

            using (var stream = new System.IO.FileStream(Path, System.IO.FileMode.Open))
            {
                return JsonSerializer.Deserialize<AppSettings>(stream);
            }
        }

        public void Write(AppSettings settings)
        {
            var bytes = JsonSerializer.Serialize(settings);

            using (var stream = new System.IO.FileStream(Path, System.IO.FileMode.Create))
            {
                stream.Write(bytes);
                stream.Flush(true);
            }
        }
    }
}