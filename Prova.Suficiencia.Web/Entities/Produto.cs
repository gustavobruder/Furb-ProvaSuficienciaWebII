namespace Prova.Suficiencia.Web.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int IdComanda { get; set; }
        public virtual Comanda Comanda { get; set; }
    }
}