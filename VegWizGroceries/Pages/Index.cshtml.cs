using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VegWizGroceries.Models;

namespace VegWizGroceries.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int Quantity { get; set; } = 1;
        [BindProperty]
        public int Rating { get; set; }
        [BindProperty]
        public string Feedback { get; set; }

        public List<GroceryItem> Foods = Inventory.ToList();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task OnPostAsync()
        {
            using (StreamWriter sw = new StreamWriter("feedback.txt", append: true))
            {
                await sw.WriteLineAsync($"{DateTime.Now} - Rating: {Rating}");
                await sw.WriteLineAsync(Feedback);
            }
        }
    }
}
