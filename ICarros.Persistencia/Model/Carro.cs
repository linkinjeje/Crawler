using System;

namespace ICarros.Persistencia.Model
{
    public class Carro
    {
        public Carro()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Km { get; set; }
        public string Cor { get; set; }
        public string Cambio { get; set; }
        public string Ano { get; set; }
        public Decimal Valor { get; set; }
    }
}
