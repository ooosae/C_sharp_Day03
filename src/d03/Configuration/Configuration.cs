namespace d03.Configuration;
using d03.Configuration.Sources;

public class Configuration
{
    private readonly List<IConfigurationSource> _sources;
    public Dictionary<string, (object Value, int Priority)> Params { get; private set; }

    public Configuration(List<IConfigurationSource> sources)
    {
        this._sources = sources;
        Params = new Dictionary<string, (object Value, int Priority)>();
        LoadConfiguration();
    }

    private void LoadConfiguration()
    {
        foreach (var source in _sources.OrderBy(s => s.Priority))
        {
            var sourceConfig = source.Load();
            foreach (var kvp in sourceConfig)
            {
                if (!Params.ContainsKey(kvp.Key) || Params[kvp.Key].Priority < source.Priority)
                {
                    Params[kvp.Key] = (kvp.Value, source.Priority);
                }
            }
        }
    }
}