using Newtonsoft.Json;
using System.IO;
namespace MiniDot
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ConfigModel
    {
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }
        [JsonProperty("projectDescription")]
        public string ProjectDescription { get; set; }
        [JsonProperty("projectVersion")]
        public string ProjectVersion { get; set; }
        [JsonProperty("baseRepoUrl")]
        public string BaseRepoUrl { get; set; }
        [JsonProperty("sourceFiles")]
        public string[] SourceFiles { get; set; }
    }

    public class ConfigReader
    {
        public ConfigModel Configuration { get; set; }
        public ConfigReader(string configPath, string configFileName = "minidot.json")
        {
            Configuration = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(Path.Combine(configPath, configFileName)));
            System.Console.WriteLine(JsonConvert.SerializeObject(Configuration));
        }
    }
}