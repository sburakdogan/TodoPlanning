using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoPlanning.Business.Abstract;

namespace TodoPlanning.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITodoOperations _todoOperations;

        public IndexModel(ITodoOperations todoOperations)
        {
            _todoOperations = todoOperations;
        }

        public async Task OnGet()
        {
            var developers = await _todoOperations.GetTaskPlan();

            var providerTotalDaysMap = new Dictionary<string, int>();

            foreach (var providerGroup in developers.GroupBy(x => x.ProviderName).ToList())
            {
                var providerName = providerGroup.Key;
                var providerTotalHours = 0;

                foreach (var developer in providerGroup)
                {
                    providerTotalHours += developer.TotalCapacity;
                }

                providerTotalDaysMap.Add(providerName, (int)Math.Ceiling((45 * 5 - providerTotalHours) / 24.0));
            }

            ViewData["Developers"] = developers;
            ViewData["TotalDays"] = providerTotalDaysMap;
        }
    }
}