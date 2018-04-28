namespace map_vigenere.Models
{
    public interface ICifra
    {
         string CifrarDados(string entrada, string chave, bool encipher);
    }
}