using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.Classes;
using Plancher_Expert.outils;
using System.Runtime.Intrinsics.Arm;

namespace Plancher_Expert.Pages
{
    public class addFournitureModel : PageModel
    {
        public Fourniture f = new Fourniture();
        public void OnGet()
        {
            f.FloorType = Request.Query["FloorType"];
            f.MaterialRate = Convert.ToDouble(Request.Query["MaterialRate"]);
            f.LaborRate = Convert.ToDouble(Request.Query["LaborRate"]);
            f.nomID = Request.Query["nomID"];
            f.Description = Request.Query["Description"];

            Functions.addFourniture(f.FloorType, f.MaterialRate, f.LaborRate, f.nomID, f.Description);
            
        }
       public void OnPost() 
       { 
       }
    }
}
