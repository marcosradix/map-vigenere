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
        
              public IActionResult Sobre()
        {
            
            return View();
        }

         public IActionResult Executar(IndexViewModel dados)
        {
            if(!dados.verificar){
                 dados.saidaTextoCifrado = $"Dados Encriptados: {EncipherDecipher(dados.entradaTextoClaro, dados.chave ,dados.verificar)}";
            }else{
                dados.saidaTextoCifrado = $"Dados Desciptados: {EncipherDecipher(dados.entradaTextoClaro, dados.chave ,dados.verificar)}";
            }
            return View("Index", dados);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public static string EncipherDecipher(string input, string key, bool encipher)
        {
            return IndexViewModel.Cipher(input, key, encipher);
        }

    }
}
