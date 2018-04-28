namespace map_vigenere.Models
{
    public interface IDecifra
    {
         string DecifrarDados(string entrada, string chave, bool encipher);
    }
}