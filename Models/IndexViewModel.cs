using System;

namespace map_vigenere.Models
{
    public class IndexViewModel
    {
        public string entradaTextoClaro { get; set; }
        public string saidaTextoCifrado { get; set; }
        public string chave { get; set; }
        public bool verificar { get; set; }
        public ICifra ICifraComportamento = null;

        public IDecifra IDecifraComportamento = null;

        public String metodoCifrar()
        {
            ICifraComportamento = new Cifrar();
            return ICifraComportamento.CifrarDados(entradaTextoClaro, chave, true);
        }
        public String metodoDecifrar()
        {
			IDecifraComportamento = new Decifrar();
            return IDecifraComportamento.DecifrarDados(entradaTextoClaro, chave, false);
        }

    }


}