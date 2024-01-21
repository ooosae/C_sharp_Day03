namespace d03.Configuration.Sources;

public interface IConfigurationSource
{
    int Priority { get; }
    Dictionary<string, object> Load();
}

