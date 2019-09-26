using Newtonsoft.Json;
using System.IO;
namespace MiniDot
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SourceConfigModel
    {
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }
        [JsonProperty("projectDescription")]
        public string ProjectDescription { get; set; }
        [JsonProperty("projectVersion")]
        public string ProjectVersion { get; set; }
        [JsonProperty("baseRepoUrl")]
        public string BaseRepoUrl { get; set; }
        [JsonProperty("sourceFile")]
        public string SourceFile { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class BaseConfigModel
    {
        [JsonProperty("baseSourceFile")]
        public string BaseSourceFile { get; set; }
    }

    public class ConfigReader
    {
        public SourceConfigModel ReadSourceConfig(string configPath, string configFileName = "minidot.json")
        {
            SourceConfigModel config = JsonConvert.DeserializeObject<SourceConfigModel>(File.ReadAllText(Path.Combine(configPath, configFileName)));
            return config;
        }

        public BaseConfigModel ReadBaseConfig(string configPath, string configFileName = "minidot-base.json")
        {
            BaseConfigModel config = JsonConvert.DeserializeObject<BaseConfigModel>(File.ReadAllText(Path.Combine(configPath, configFileName)));
            return config;
        }
    }
}