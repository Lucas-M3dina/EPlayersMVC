using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Eplayers.Models;

namespace MVC_Eplayers.Controllers
{
    [Route("Login")]
    public class LoginController: Controller
    {
        [TempData]
        public string Mensagem { get; set; }
        Jogador JogadorModel = new Jogador();

        public IActionResult Index(){

            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){
            List<string> JogadoresCsv = JogadorModel.LerTodasLinhasCSV("Database/Jogador.csv");
            var logado = JogadoresCsv.Find(x => x.Split(";")[3] == form["Email"] && x.Split(";")[4] == form["Senha"] );
            
            if (logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                return LocalRedirect("~/");
            }
            
            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}