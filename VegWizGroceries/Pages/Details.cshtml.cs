using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using VegWizGroceries.Models;

namespace VegWizGroceries.Pages
{
    public class DetailsModel : PageModel
    {
        public List<GroceryItem> Foods = Inventory.ToList();
        public GroceryItem CurrentFood;

        public void OnGet(string name)
        {
            CurrentFood = Foods.Find(food => food.Name.ToLower() == name.ToLower());
        }
    }
}
