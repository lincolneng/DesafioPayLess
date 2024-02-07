using PayLess.Data;
using PayLess.Models;
using PayLess.Service.Interface;

namespace PayLess.Service
{
    public class LojaService : ILojaService
    {
        AppDbContext _context;

        public LojaService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public bool CreateLoja(Loja loja)
        {
            _context.Lojas.Add(loja);
            _context.SaveChanges();
            return true;
        }

        public Loja DeleteLoja(int id)
        {
            var loja = _context.Lojas.FirstOrDefault(x => x.Id == id);

            if (loja == null)
            {
                throw new Exception();
            }

            _context.Lojas.Remove(loja);
            _context.SaveChanges();
            return loja;
        }

        public List<Loja> GetLoja()
        {
            var lojas = _context.Lojas.ToList();
            return lojas;
        }

        public Loja GetLojaById(int id)
        {
            try
            {
                var loja = _context.Lojas.FirstOrDefault(x => x.Id == id);

                if (loja == null)
                {
                    throw new Exception();
                }
                return loja;

            }
            catch (Exception ex)
            {
                throw new Exception("nao encontrado");
            }
        }

        public Loja UpdateLoja(Loja loja, int id)
        {
            var oldLoja = _context.Lojas.FirstOrDefault(x => x.Id == id);

            if (oldLoja == null)
            {
                throw new Exception();
            }
            oldLoja.Nome = loja.Nome;
            oldLoja.Endereço = loja.Endereço;
            _context.Lojas.Update(oldLoja);
            _context.SaveChanges();
            return loja;
        }
    }
}
