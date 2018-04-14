namespace map_vigenere.Models
{
    public interface ICifra
    {
         string CifraDecifra(string entrada, string chave, bool encipher);
    }
}