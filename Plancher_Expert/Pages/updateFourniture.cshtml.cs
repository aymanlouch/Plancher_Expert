using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.Classes;
using Plancher_Expert.outils;

namespace Plancher_Expert.Pages
{
    public class updateFournitureModel : PageModel
    {
        public int IdP { get; set; } = 0;
        public double MaterialRate { get; set; } = 0;
        public double LaborRate { get; set; } = 0;

        public List<Fourniture> fournitureList = new List<Fourniture>();
        public bool HasData { get; set; } = false;

        public void OnGet()
        {
            HasData = true;
            fournitureList = Functions.getFourniture();
            IdP = Convert.ToInt32(Request.Query["IdP"]);
            LaborRate = Convert.ToDouble(Request.Query["LaborRate"]);
            MaterialRate = Convert.ToDouble(Request.Query["MaterialRate"]);

            Functions.updateFourniture(IdP, LaborRate, MaterialRate);
        }
        public void OnPost()
        {
            RedirectToAction("gestionFourniture");
        }
    }
}
