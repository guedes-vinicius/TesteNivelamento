using System;

namespace Domain.Entities

{
    public class Movimento
    {
        public Guid IdMovimento { get; set; }
        public string IdContaCorrente { get; set; }
        public string DataMovimento { get; set; }
        public char TipoMovimento { get; set; }
        public decimal Valor { get; set; }

    }
}