using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.Classes;
using Plancher_Expert.outils;

namespace Plancher_Expert.User
{
    public class RegisterModel : PageModel
    {
        public Users utilisateurData { get; set; } = new Users();
        public string msgError = "";
        public void OnGet()
        {
            HttpContext.Session.Remove("userExist");
        }

        public void OnPost()
        {
            utilisateurData.firstName = Request.Form["firstName"];
            utilisateurData.lastName = Request.Form["lastName"];
            utilisateurData.userLogin = Request.Form["email"];
            utilisateurData.userPw = Request.Form["pw"];

            if (utilisateurData.userLogin == "" || utilisateurData.userPw == "" || utilisateurData.firstName == "" || utilisateurData.lastName == "")
            {
                msgError = "Veuillez saisir Vos informations";
                return;
            }

            if (Functions.VerifierUtilisateurExiste(utilisateurData.userLogin))
            {
                HttpContext.Session.SetString("userExist", "Cet utilisateur deja existe");
                return;
            }
            else
            {
                Functions.addUser(utilisateurData.firstName, utilisateurData.lastName, utilisateurData.userLogin, utilisateurData.userPw);
                Response.Redirect("/User/Login");
            }
        }
    }
}
