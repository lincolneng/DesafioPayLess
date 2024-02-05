using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PayLess.Models
{
    public class EstoqueLoja
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int LojaId { get; set; }
        public Loja Loja { get; set; }
        public int Quantidade { get; set; }
    }
}
