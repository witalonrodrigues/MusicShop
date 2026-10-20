using System;
using System.Drawing;
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
    }
}