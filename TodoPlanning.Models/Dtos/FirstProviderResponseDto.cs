namespace TodoPlanning.Models.Dtos
{
    public class FirstProviderResponseDto
    {
        public List<FirstProviderDeveloperDto> Developers { get; set; }
        public List<FirstProviderTaskDto> Tasks { get; set; }
    }

    public class FirstProviderDeveloperDto
    {
        public string Name { get; set; }
        public int Hourly_Capacity { get; set; }
    }
    
    public class FirstProviderTaskDto
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
    }
}
