using MusicShop.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace MusicShop
{
    public class FormRelatorio : Form
    {
        protected DataGridView dgvVendas = new DataGridView();
        protected TextBox txtFiltro = new TextBox();
        protected Button btnFiltrar = new Button();
        protected Label lblResumo = new Label();

        public FormRelatorio()
        {
            ConfigurarLayoutRelatorio();
            CarregarDadosGrid();
        }

        private void ConfigurarLayoutRelatorio()
        {
            this.Text = "MusicShop - Relatório de Vendas";
            this.Size = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblBusca = new Label { Text = "Filtrar por Cliente/Instrumento:", Location = new Point(20, 25), AutoSize = true };
            txtFiltro.Location = new Point(200, 22);
            txtFiltro.Size = new Size(250, 25);

            btnFiltrar.Text = "Pesquisar";
            btnFiltrar.Location = new Point(465, 20);
            btnFiltrar.Size = new Size(100, 28);

            dgvVendas.Location = new Point(20, 65);
            dgvVendas.Size = new Size(640, 280);
            dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendas.ReadOnly = true;
            dgvVendas.AllowUserToAddRows = false;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            lblResumo.Text = "Total de Vendas: 0 | Faturamento Total: R$ 0,00";
            lblResumo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblResumo.Location = new Point(20, 365);
            lblResumo.AutoSize = true;

            this.Controls.AddRange(new Control[] { lblBusca, txtFiltro, btnFiltrar, dgvVendas, lblResumo });
        }
        private void ConfigurarEventosRelatorio()
        {
            if (BancoDadosMemoria.Vendas.Count == 0)
            {
                BancoDadosMemoria.Vendas.Add(new VendaInstrumento
                {
                    Id = 1,
                    Cliente = "Cliente Demonstração",
                    Instrumento = "Guitarra Fender Stratocaster",
                    Quantidade = 1,
                    PrecoUnitario = 4500m,
                    DataVenda = DateTime.Now
                });
            }

            btnFiltrar.Click += (s, e) => CarregarDadosGrid(txtFiltro.Text);
            txtFiltro.TextChanged += (s, e) => CarregarDadosGrid(txtFiltro.Text);
        }
        protected void CarregarDadosGrid(string filtro = "")
        {
            var lista = BancoDadosMemoria.Vendas.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                lista = lista.Where(v =>
                    v.Cliente.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    v.Instrumento.Contains(filtro, StringComparison.OrdinalIgnoreCase));
            }

            var resultado = lista.ToList();
            dgvVendas.DataSource = null;
            dgvVendas.DataSource = resultado;

            decimal faturamento = resultado.Sum(v => v.Total);
            lblResumo.Text = $"Total de Pedidos: {resultado.Count} | Faturamento Acumulado: {faturamento:C2}";
        }
    }
}