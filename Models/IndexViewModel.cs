using System;

namespace map_vigenere.Models
{
    public class IndexViewModel
    {
        public string entradaTextoClaro { get; set; }
        public string saidaTextoCifrado { get; set; }
        public string chave { get; set; }
        public bool verificar { get; set; }
        public ICifra ICifraComportamento { get; set; }

        public String metodoCifrar()
        {
            ICifraComportamento = new Cifrar();
            return ICifraComportamento.CifraDecifra(entradaTextoClaro, chave, true);
        }
        public String metodoDecifrar()
        {
			ICifraComportamento = new Decifrar();
            return ICifraComportamento.CifraDecifra(entradaTextoClaro, chave, false);;
        }

    }


}