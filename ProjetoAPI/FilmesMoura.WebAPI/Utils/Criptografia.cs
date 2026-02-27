namespace FilmesMoura.WebAPI.Utils;

public  static class Criptografia
{
    public static string GerarHash(string valor)
    {
        return BCrypt.Net.BCrypt.HashPassword(valor);
    }

    public static bool CompararHash(string senhaForm, string SenhaBanco)
    {
        return BCrypt.Net.BCrypt.Verify(senhaForm, SenhaBanco);
    }
}
