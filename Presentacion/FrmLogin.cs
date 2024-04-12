using Entidades;
using LogicaNegocio;
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
    public partial class FrmLogin : Form
    {
        private ClsUsuario ObjUsuario = null;
        private readonly ClsUsuarioLn objUsuarioln = new ClsUsuarioLn();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ObjUsuario = new ClsUsuario()
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text,

            };
            objUsuarioln.Validar(ref ObjUsuario);

            if (ObjUsuario.MensajeError == null)
            {
                if (ObjUsuario.DtResultado.Rows.Count > 0)
                {
                    MessageBox.Show("Bienvenido SoftCitas " + ObjUsuario.Email);
                    FrmMenu menu = new FrmMenu();
                    menu.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show(ObjUsuario.MensajeError, "Usuario y/o contraseña erroneos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error BD " + ObjUsuario.MensajeError);
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            crearusuario crau = new crearusuario();
            crau.Show();
            this.Hide();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Pink;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Pink;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "contraseña")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Pink;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "contraseña";
                txtPassword.ForeColor = Color.Pink;
            }
        }
    }
}
