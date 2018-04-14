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
            IndexViewModel valores = new IndexViewModel();
            return View(valores);
        }
        
              public IActionResult Sobre()
        {
            
            return View();
        }

         public IActionResult Executar(IndexViewModel dados)
        {
            if(!dados.verificar){
                    dados.saidaTextoCifrado = dados.metodoCifrar();
                 if( dados.saidaTextoCifrado == null){
                     dados.saidaTextoCifrado = $"A chave não pode conter números!";
                 }else{
                     dados.saidaTextoCifrado = $"Dados Encriptados: {dados.saidaTextoCifrado}";
                 }

            }else{
                dados.saidaTextoCifrado = dados.metodoDecifrar();
                if( dados.saidaTextoCifrado == null){
                      dados.saidaTextoCifrado = $"A chave não pode conter números!";
                }else{
                     dados.saidaTextoCifrado = $"Dados Desciptados: {dados.saidaTextoCifrado}";
                }
            }
            return View("Index", dados);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
