using PayLess.Models;

namespace PayLess.Service.Interface
{
    public interface ILojaService
    {
        Loja GetLojaById(int id);
        List<Loja> GetLoja();
        bool CreateLoja(Loja loja);
        Loja UpdateLoja(Loja loja, int id);
        Loja DeleteLoja(int id);
    }
}
