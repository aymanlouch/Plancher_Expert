using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plancher_Expert.outils;
using Plancher_Expert.Classes;
namespace Plancher_Expert.User
{
    public class LoginModel : PageModel
    {
        public Users utilisateurData { get; set; } = new Users();
        public string msgError = "";
        public void OnGet()
        {
            HttpContext.Session.Remove("userNotExist");
            HttpContext.Session.Remove("userPwError");
        }
        public void OnPost()
        {
            utilisateurData.userLogin = Request.Form["email"];
            utilisateurData.userPw = Request.Form["pw"];

            if (utilisateurData.userLogin == "" || utilisateurData.userPw == "")
            {
                msgError = "Veuillez saisir Votre login et votre mot de passe";
                return;
            }

            if (!Functions.VerifierUtilisateurExiste(utilisateurData.userLogin))
            {
                HttpContext.Session.SetString("userNotExist", "Cet utilisateur n'existe pas");
                return;
            }

            if (!Functions.VerifierPw(utilisateurData.userLogin, utilisateurData.userPw))
            {
                HttpContext.Session.SetString("userPwError", "Le mot de passe saisi est incorrecte");
                return;
            }
            else
            {
                utilisateurData = Functions.getUser(utilisateurData.userLogin, utilisateurData.userPw);

                HttpContext.Session.SetString("userAuthenticated", "true");
                HttpContext.Session.SetString("userId", Convert.ToString(utilisateurData.id));
                HttpContext.Session.SetString("userFirstName", Convert.ToString(utilisateurData.firstName));
                HttpContext.Session.SetString("userLastName", Convert.ToString(utilisateurData.lastName));
                HttpContext.Session.SetString("userLogin", Convert.ToString(utilisateurData.userLogin));
                HttpContext.Session.SetString("userType", Convert.ToString(utilisateurData.userType));

                Console.WriteLine(HttpContext.Session.GetString("userType"));
                Response.Redirect("/Index");
            }
        }
    }
}
