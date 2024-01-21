using d03.Configuration;
using d03.Configuration.Sources;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 4)
        {
            Console.WriteLine("Invalid data. Check your input and try again.");
            return;
        }

        try
        {
            string jsonPath = args[0];
            int jsonPriority = int.Parse(args[1]);
            string yamlPath = args[2];
            int yamlPriority = int.Parse(args[3]);

            IConfigurationSource jsonSource = new JsonSource(jsonPath, jsonPriority);
            IConfigurationSource yamlSource = new YamlSource(yamlPath, yamlPriority);

            var configuration = new Configuration(new List<IConfigurationSource> { jsonSource, yamlSource });
            ProcessConfiguration(configuration);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid data. Check your input and try again.");
        }
    }

    static void ProcessConfiguration(Configuration config)
    {
        Console.WriteLine("Configuration:");
        foreach (var kvp in config.Params)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value.Value}");
        }
    }
}