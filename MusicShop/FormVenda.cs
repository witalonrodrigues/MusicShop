using MusicShop.Models;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace MusicShop
{
    public class FormVenda : Form
    {
        protected TextBox txtCliente = new TextBox();
        protected ComboBox cmbInstrumento = new ComboBox();
        protected NumericUpDown numQuantidade = new NumericUpDown();
        protected TextBox txtPreco = new TextBox();
        protected Label lblTotalValor = new Label();
        protected Button btnSalvar = new Button();
        protected Button btnLimpar = new Button();

        private readonly CultureInfo _culturaBr = new CultureInfo("pt-BR");

        public FormVenda()
        {
            ConfigurarComponentesVisuais();
            ConfigurarEventosCalculo();
            ConfigurarBotoesAcao();
        }

        private void ConfigurarBotoesAcao()
        {
            btnSalvar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtCliente.Text) || cmbInstrumento.SelectedIndex < 0)
                {
                    MessageBox.Show("Preencha o cliente e selecione um instrumento!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse usando pt-BR para evitar que 6800,00 vire 680000
                if (!decimal.TryParse(txtPreco.Text, NumberStyles.Number, _culturaBr, out decimal preco) || preco <= 0)
                {
                    MessageBox.Show("Informe um preço válido!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var novaVenda = new VendaInstrumento
                {
                    Id = BancoDadosMemoria.Vendas.Count + 1,
                    Cliente = txtCliente.Text.Trim(),
                    Instrumento = cmbInstrumento.SelectedItem?.ToString() ?? "",
                    Quantidade = (int)numQuantidade.Value,
                    PrecoUnitario = preco,
                    DataVenda = DateTime.Now
                };

                BancoDadosMemoria.Vendas.Add(novaVenda);
                MessageBox.Show("Venda registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparFormulario();
            };

            btnLimpar.Click += (s, e) => LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtCliente.Clear();
            cmbInstrumento.SelectedIndex = -1;
            numQuantidade.Value = 1;
            txtPreco.Clear();
            lblTotalValor.Text = "R$ 0,00";
            txtCliente.Focus();
        }

        private void ConfigurarComponentesVisuais()
        {
            this.Text = "MusicShop - Lançamento de Vendas";
            this.Size = new Size(450, 380);
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblCliente = new Label { Text = "Nome do Cliente:", Location = new Point(30, 30), AutoSize = true };
            txtCliente.Location = new Point(160, 27);
            txtCliente.Size = new Size(230, 25);

            Label lblInst = new Label { Text = "Instrumento:", Location = new Point(30, 75), AutoSize = true };
            cmbInstrumento.Location = new Point(160, 72);
            cmbInstrumento.Size = new Size(230, 25);
            cmbInstrumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInstrumento.Items.AddRange(new string[] {
                "Guitarra Fender Stratocaster",
                "Violão Takamine Aço",
                "Baixo Yamaha 4 Cordas",
                "Bateria Acústica Pearl",
                "Teclado Sintetizador Roland"
            });

            Label lblQtd = new Label { Text = "Quantidade:", Location = new Point(30, 120), AutoSize = true };
            numQuantidade.Location = new Point(160, 118);
            numQuantidade.Size = new Size(100, 25);
            numQuantidade.Minimum = 1;
            numQuantidade.Maximum = 50;

            Label lblPreco = new Label { Text = "Preço Unitário (R$):", Location = new Point(30, 165), AutoSize = true };
            txtPreco.Location = new Point(160, 162);
            txtPreco.Size = new Size(120, 25);

            Label lblTotalTexto = new Label { Text = "Total do Pedido:", Location = new Point(30, 215), Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true };
            lblTotalValor.Text = "R$ 0,00";
            lblTotalValor.Location = new Point(160, 215);
            lblTotalValor.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTotalValor.ForeColor = Color.DarkGreen;
            lblTotalValor.AutoSize = true;

            btnSalvar.Text = "Finalizar Venda";
            btnSalvar.Location = new Point(80, 270);
            btnSalvar.Size = new Size(130, 40);

            btnLimpar.Text = "Limpar Campos";
            btnLimpar.Location = new Point(230, 270);
            btnLimpar.Size = new Size(130, 40);

            this.Controls.AddRange(new Control[] {
                lblCliente, txtCliente, lblInst, cmbInstrumento,
                lblQtd, numQuantidade, lblPreco, txtPreco,
                lblTotalTexto, lblTotalValor, btnSalvar, btnLimpar
            });
        }

        private void ConfigurarEventosCalculo()
        {
            cmbInstrumento.SelectedIndexChanged += (s, e) =>
            {
                txtPreco.Text = cmbInstrumento.SelectedIndex switch
                {
                    0 => "4500,00",
                    1 => "2200,00",
                    2 => "1900,00",
                    3 => "6800,00",
                    4 => "3400,00",
                    _ => "0,00"
                };
                AtualizarTotal();
            };

            numQuantidade.ValueChanged += (s, e) => AtualizarTotal();
            txtPreco.TextChanged += (s, e) => AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            if (decimal.TryParse(txtPreco.Text, NumberStyles.Number, _culturaBr, out decimal preco))
            {
                decimal total = preco * numQuantidade.Value;
                lblTotalValor.Text = total.ToString("C2", _culturaBr);
            }
            else
            {
                lblTotalValor.Text = 0.ToString("C2", _culturaBr);
            }
        }
    }
}