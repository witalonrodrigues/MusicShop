using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace MusicShop
{
    public class FormSplash : Form
    {
        private ProgressBar progressBar = new ProgressBar();
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private Label lblTitulo = new Label();
        private Label lblStatus = new Label();

        public FormSplash()
        {
            this.Text = "MusicShop - Carregando...";
            this.Size = new Size(450, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(30, 30, 45);

            lblTitulo.Text = "🎸 MUSIC SHOP SYSTEM";
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(85, 60);

            lblStatus.Text = "Inicializando módulos...";
            lblStatus.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblStatus.ForeColor = Color.LightGray;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(150, 110);

            progressBar.Location = new Point(50, 150);
            progressBar.Size = new Size(350, 25);
            progressBar.Value = 0;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblStatus);
            this.Controls.Add(progressBar);

            timer.Interval = 40;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (progressBar.Value < 100)
            {
                progressBar.Value += 5;
            }
            else
            {
                timer.Stop();
                FormMenu menu = new FormMenu();
                menu.Show();
                this.Hide();
            }
        }
    }
}