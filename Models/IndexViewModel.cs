using System;

namespace map_vigenere.Models
{
    public class IndexViewModel
    {
        public string entradaTextoClaro { get; set; }
        public string saidaTextoCifrado { get; set; }
         public string chave { get; set; }
        public bool verificar { get; set; }
        private static int tamanhoAlfabeto {get; set;} = 26;

    private static int Mod(int a, int b)
    {
        return (a % b + b) % b;
    }
    public static string Cipher(string entrada, string chave, bool encipher)
    {
	for (int i = 0; i < chave.Length; ++i)
		if (!char.IsLetter(chave[i]))
			return null; // Error

	string saida = string.Empty;
	int contador = 0;

	for (int i = 0; i < entrada.Length; ++i)
	{
		if (char.IsLetter(entrada[i]))
		{
			bool deixarTextoUpper = char.IsUpper(entrada[i]);
			char deslocar = deixarTextoUpper ? 'A' : 'a';
			int chaveIndex = (i - contador) % chave.Length;
			int k = (deixarTextoUpper ? char.ToUpper(chave[chaveIndex]) : char.ToLower(chave[chaveIndex])) - deslocar;
			k = encipher ? k : -k;
			char ch = (char)((Mod(((entrada[i] + k) - deslocar), tamanhoAlfabeto)) + deslocar);
			saida += ch;
		}
		else
		{
			saida += entrada[i];
			++contador;
		}
	}

	return saida;
    }


    }
}