using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.Classes;
using Plancher_Expert.outils;
using System.Collections.Specialized;
using System.Data.SqlClient;


namespace Plancher_Expert.Pages
{
    public class FactureModel : PageModel
    {
		public double Length { get; set; } = 0;
		public double Width { get; set; } = 0;
		public double MaterialRate { get; set; } = 0;
		public double LaborRate { get; set; } = 0;
		public double Area { get; set; } = 0;
		public double MaterialCost { get; set; } = 0;
		public double InstallationCost { get; set; } = 0;
		public double CostHT { get; set; } = 0;
		public double TVA { get; set; } = 0;
		public double TotalCost { get; set; } = 0;
		public string FloorType { get; set; } = "";
        public int IdP { get; set; } = 0;
		public string nomC { get; set; } = "";
		public string prenomC { get; set; } = "";
		public string addressC { get; set; } = "";
		public string telC { get; set; } = "";

		public bool HasData { get; set; } = false;

        public void OnGet()
        {
			HasData = true;
            //Inputs Values
            IdP = Convert.ToInt32(Request.Query["IdP"]);
            Length = Convert.ToDouble(Request.Query["length"]);
			Width = Convert.ToDouble(Request.Query["width"]);
			nomC = Request.Query["nomC"];
            prenomC = Request.Query["prenomC"];
            addressC = Request.Query["addressC"];
            telC = Request.Query["telC"];


            Area = Width * Length;

			//Get values from DataBase
			Fourniture f = Functions.getFournitureById(IdP);
			FloorType = f.FloorType;
			MaterialRate = f.MaterialRate;
			LaborRate = f.LaborRate;

			//calcul du cout du materiel
			MaterialCost = MaterialRate * Area;
			MaterialCost = Math.Round(MaterialCost,2);

			//calcul du cout de la main d'oeuvre
			InstallationCost = LaborRate * Area;
			InstallationCost = Math.Round(InstallationCost,2);

			//calcul du cout HT
			CostHT = MaterialCost + InstallationCost;
			CostHT = Math.Round(CostHT, 2);

			//calcul de la TVA
			TVA = (MaterialCost + InstallationCost) * 0.15;
			TVA = Math.Round(TVA, 2);

			//cout total
			TotalCost = MaterialCost + InstallationCost + TVA;

			//add Facture to DataBase
			Functions.addToFactureTable(f.Id, Area, TotalCost, nomC, prenomC, addressC, telC, Length, Width);
		}


        

    }
}
