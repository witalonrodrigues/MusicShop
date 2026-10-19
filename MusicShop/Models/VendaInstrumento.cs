using System;
using System.Collections.Generic;

namespace MusicShop.Models
{
    public class VendaInstrumento
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Instrumento { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total => Quantidade * PrecoUnitario;
        public DateTime DataVenda { get; set; } = DateTime.Now;
    }

    public static class BancoDadosMemoria
    {
        public static List<VendaInstrumento> Vendas { get; set; } = new List<VendaInstrumento>();
    }
}