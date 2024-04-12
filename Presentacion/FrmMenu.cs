using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        Panel p = new Panel();
        private void btnMouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            pMenu.Controls.Add(p);
            p.BackColor = Color.FromArgb(90, 210, 2);
            p.Size = new Size(130, 5);
            p.Location = new Point(btn.Location.X, btn.Location.Y + 40);
        }

        private void btnMouseLeave(object sender, EventArgs e)
        {
            pMenu.Controls.Remove(p);
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            Pacientes fpac = new Pacientes();
            fpac.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Medicos fmed = new Medicos();
            fmed.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
