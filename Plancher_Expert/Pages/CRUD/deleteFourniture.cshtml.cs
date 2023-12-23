using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.Classes;
using Plancher_Expert.outils;

namespace Plancher_Expert.Pages.CRUD
{
    public class deleteFournitureModel : PageModel
    {
        public int IdP { get; set; } = 0;

        public List<Fourniture> fournitureList = new List<Fourniture>();
        public void OnGet()
        {

            if (HttpContext.Session.GetString("userType") != "admin")
                Response.Redirect("/User/Login");
            else
            {
                IdP = Convert.ToInt32(Request.Query["IdP"]);
                Functions.deleteFourniture(IdP);
                RedirectToAction("/crud/gestionFourniture");
            }
        }

    }
}
