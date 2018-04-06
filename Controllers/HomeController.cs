using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using map_vigenere.Models;

namespace map_vigenere.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IndexViewModel dados = new IndexViewModel();
            return View(dados);
        }
        
              public IActionResult About()
        {
            
            return View();
        }

         public IActionResult Executar(IndexViewModel dados)
        {
            if(!dados.verificar){
                 dados.saidaTextoCifrado = $"Dados Encriptados: {dados.entradaTextoClaro}";
            }else{
                dados.saidaTextoCifrado = $"Dados Desciptados: {dados.entradaTextoClaro}";
            }
            return View("Index", dados);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
