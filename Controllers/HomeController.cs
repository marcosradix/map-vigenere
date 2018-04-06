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

private static int Mod(int a, int b)
{
	return (a % b + b) % b;
}
    private static string Cipher(string input, string key, bool encipher)
    {
	for (int i = 0; i < key.Length; ++i)
		if (!char.IsLetter(key[i]))
			return null; // Error

	string output = string.Empty;
	int nonAlphaCharCount = 0;

	for (int i = 0; i < input.Length; ++i)
	{
		if (char.IsLetter(input[i]))
		{
			bool cIsUpper = char.IsUpper(input[i]);
			char offset = cIsUpper ? 'A' : 'a';
			int keyIndex = (i - nonAlphaCharCount) % key.Length;
			int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
			k = encipher ? k : -k;
			char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
			output += ch;
		}
		else
		{
			output += input[i];
			++nonAlphaCharCount;
		}
	}

	return output;
}

public static string EncipherDecipher(string input, string key, bool encipher)
{
	return Cipher(input, key, encipher);
}

    }
}
