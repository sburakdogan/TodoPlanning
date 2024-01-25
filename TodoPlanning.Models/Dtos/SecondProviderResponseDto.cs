namespace TodoPlanning.Models.Dtos
{
    public class SecondProviderResponseDto
    {
        public List<SecondProviderDeveloperDto> Developers { get; set; }
        public List<SecondProviderTaskDto> Tasks { get; set; }
    }

    public class SecondProviderDeveloperDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }

    public class SecondProviderTaskDto
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
    }
}
