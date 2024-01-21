namespace d03.Configuration.Sources;

using YamlDotNet.Serialization;

public class YamlSource : IConfigurationSource
{
    private readonly string _filePath;
    public int Priority { get; }
    
    public YamlSource(string filePath, int priority)
    {
        this._filePath = filePath;
        Priority = priority;
    }

    public Dictionary<string, object> Load()
    {
        try
        {
            string yamlContent = File.ReadAllText(_filePath);
            var deserializer = new DeserializerBuilder().Build();
            var configDictionary = deserializer.Deserialize<Dictionary<string, object>>(yamlContent);
            return configDictionary;
        }
        finally{}
    }
}