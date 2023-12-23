using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.Classes;
using Plancher_Expert.outils;

namespace Plancher_Expert.Pages.CRUD
{
    public class gestionFournitureModel : PageModel
    {
        public List<Fourniture> fournitureList = new List<Fourniture>();
        public void OnGet()
        {
            fournitureList = Functions.getFourniture();

            if (HttpContext.Session.GetString("userType") != "admin")
                Response.Redirect("/User/Login");
        }
    }
}
