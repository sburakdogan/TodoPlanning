namespace TodoPlanning.Data.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public string ProviderName { get; set; }
    }
}
