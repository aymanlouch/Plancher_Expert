using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.Classes;
using Plancher_Expert.outils;
using System.Runtime.Intrinsics.Arm;

namespace Plancher_Expert.Pages.CRUD
{
    public class addFournitureModel : PageModel
    {
        public Fourniture f = new Fourniture();
        public void OnGet()
        {
            if (HttpContext.Session.GetString("userType") != "admin")
                Response.Redirect("/User/Login");
        }
        public void OnPost()
        {
            f.FloorType = Request.Form["FloorType"];
            f.MaterialRate = Convert.ToDouble(Request.Form["MaterialRate"]);
            f.LaborRate = Convert.ToDouble(Request.Form["LaborRate"]);
            f.nomID = Request.Form["nomID"];
            f.Description = Request.Form["Description"];

            Functions.addFourniture(f.FloorType, f.MaterialRate, f.LaborRate, f.nomID, f.Description);
            Response.Redirect("/crud/GestionFourniture");
        }
    }
}
