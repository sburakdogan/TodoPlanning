using TodoPlanning.Models.Dtos;

namespace TodoPlanning.Business
{
    public class TaskPlanning
    {
        public static List<DeveloperDto> AssignTasksToDevelopers(List<DeveloperDto> developers, List<TaskDto> tasks)
        {
            tasks = tasks.OrderByDescending(x => x.Duration).ThenBy(x => x.Difficulty).ToList();
            developers = developers.OrderByDescending(x => x.HourlyCapacity).ToList();

            foreach (var developer in developers)
            {
                foreach (var task in tasks.Where(x => !x.IsAssigned && x.ProviderName == developer.ProviderName))
                {
                    if (developer.TotalCapacity >= task.Difficulty * task.Duration)
                    {
                        developer.AssignedTasks.Add(task);
                        developer.TotalCapacity -= task.Difficulty * task.Duration;

                        task.IsAssigned = true;
                    }
                }
            }

            return developers.OrderBy(x => x.ProviderName).ToList();
        }
    }
}
