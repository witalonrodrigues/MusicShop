using System;
using System.Drawing;
using System.Linq;
using Label = System.Windows.Forms.Label;
using System.Windows.Forms;

namespace MusicShop
{
    public class FormMenu : Form
    {
        public FormMenu()
        {
            this.Text = "MusicShop - Menu Principal";
            this.Size = new Size(500, 380);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblHeader = new Label
            {
                Text = "Painel Principal - Loja de Instrumentos",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(65, 30)
            };

            Button btnVendas = new Button
            {
                Text = "🛒 Lançar Venda de Instrumentos",
                Size = new Size(280, 50),
                Location = new Point(100, 90),
                Font = new Font("Segoe UI", 11)
            };
            btnVendas.Click += (s, e) => AbrirFormulario("FormVenda");

            Button btnRelatorios = new Button
            {
                Text = "📊 Relatório de Vendas",
                Size = new Size(280, 50),
                Location = new Point(100, 160),
                Font = new Font("Segoe UI", 11)
            };
            btnRelatorios.Click += (s, e) => AbrirFormulario("FormRelatorio");

            Button btnSair = new Button
            {
                Text = "❌ Encerrar Sistema",
                Size = new Size(280, 45),
                Location = new Point(100, 240),
                Font = new Font("Segoe UI", 10)
            };
            btnSair.Click += (s, e) => Application.Exit();

            this.Controls.Add(lblHeader);
            this.Controls.Add(btnVendas);
            this.Controls.Add(btnRelatorios);
            this.Controls.Add(btnSair);

            this.FormClosed += (s, e) => Application.Exit();
        }

        // Usa Reflection para não quebrar a compilação enquanto Dev 2 e Dev 3 criam as telas
        private void AbrirFormulario(string nomeClasse)
        {
            var tipo = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.Name == nomeClasse && typeof(Form).IsAssignableFrom(t));

            if (tipo != null)
            {
                Form? form = (Form?)Activator.CreateInstance(tipo);
                form?.ShowDialog();
            }
            else
            {
                MessageBox.Show($"A tela '{nomeClasse}' ainda está sendo integrada pela equipe!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
