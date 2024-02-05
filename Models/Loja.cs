using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayLess.Models
{
    public class Loja
    {
        public int Id { get; set; }
        public string Endereço { get; set; }
        public string Nome { get; set; }
        public List<EstoqueLoja> Estoque { get; set; }

    }
}
