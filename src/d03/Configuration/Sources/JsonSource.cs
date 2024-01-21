namespace d03.Configuration.Sources;

using System.Text.Json;

public class JsonSource : IConfigurationSource
{
    private readonly string _filePath;
    public int Priority { get; }
    
    public JsonSource(string filePath, int priority)
    {
        this._filePath = filePath;
        Priority = priority;
    }

    public Dictionary<string, object> Load()
    {
        try
        {
            string jsonContent = File.ReadAllText(_filePath);
            var configDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonContent);
            return configDictionary ?? new Dictionary<string, object>();
        }
        finally{}
    }
}