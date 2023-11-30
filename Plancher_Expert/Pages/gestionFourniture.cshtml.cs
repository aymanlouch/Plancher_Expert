using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.Classes;
using Plancher_Expert.outils;

namespace Plancher_Expert.Pages
{
    public class gestionFournitureModel : PageModel
    {
        public List<Fourniture> fournitureList = new List<Fourniture>();
        public void OnGet()
        {
            fournitureList = Functions.getFourniture();
        }
    }
}
