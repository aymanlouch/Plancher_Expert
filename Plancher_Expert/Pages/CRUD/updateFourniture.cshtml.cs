using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.Classes;
using Plancher_Expert.outils;

namespace Plancher_Expert.Pages.CRUD
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
            IdP = Convert.ToInt32(Request.Query["IdP"]);
            fournitureList = Functions.getFourniture();

            if (HttpContext.Session.GetString("userType") != "admin")
                Response.Redirect("/User/Login");
        }
        public void OnPost()
        {
            IdP = Convert.ToInt32(Request.Query["IdP"]);
            LaborRate = Convert.ToDouble(Request.Form["LaborRate"]);
            MaterialRate = Convert.ToDouble(Request.Form["MaterialRate"]);

            Functions.updateFourniture(IdP, LaborRate, MaterialRate);
            Response.Redirect("/crud/gestionFourniture");
        }
    }
}
