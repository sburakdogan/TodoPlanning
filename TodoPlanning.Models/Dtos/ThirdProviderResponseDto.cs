using System.Xml.Serialization;

namespace TodoPlanning.Models.Dtos
{
    [XmlRoot("project")]
    public class ThirdProviderResponseDto
    {
        [XmlArray("developers")]
        [XmlArrayItem("developer")]
        public List<ThirdProviderDeveloperDto> Developers { get; set; }

        [XmlArray("tasks")]
        [XmlArrayItem("task")]
        public List<ThirdProviderTaskDto> Tasks { get; set; }
    }

    public class ThirdProviderDeveloperDto
    {
        [XmlElement("dev_name")]
        public string Dev_Name { get; set; }

        [XmlElement("capacity_per_hour")]
        public int Capacity_Per_Hour { get; set; }
    }

    public class ThirdProviderTaskDto
    {
        [XmlElement("task_name")]
        public string Task_Name { get; set; }

        [XmlElement("task_duration")]
        public int Task_Duration { get; set; }

        [XmlElement("task_difficulty")]
        public int Task_Difficulty { get; set; }
    }
}
