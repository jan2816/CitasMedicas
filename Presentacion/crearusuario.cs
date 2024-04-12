using Entidades;
using LogicaNegocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class crearusuario : Form
    {
        private ClsUsuario ObjUsuario = null;
        private readonly ClsUsuarioLn objUsuarioln = new ClsUsuarioLn();

        public crearusuario()
        {
            InitializeComponent();
            CargarListaUsuarios();
        }
        private void CargarListaUsuarios()
        {
            ObjUsuario = new ClsUsuario();
            objUsuarioln.Index(ref ObjUsuario);

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string Clave = txtPassword.Text;
            string Cclave = txtCpassword.Text;
            if (Clave == Cclave)
            {
                ObjUsuario = new ClsUsuario()
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,


                };
                objUsuarioln.Create(ref ObjUsuario);

                if (ObjUsuario.MensajeError == null)
                {
                    MessageBox.Show("El usuario: " + ObjUsuario.Email + " fue agregado con éxito");

                }
                else
                {
                    MessageBox.Show("Error BD " + ObjUsuario.MensajeError);
                }
            }
            else
            {
                MessageBox.Show("Error");
            }


        }

        private void LimpiarCampos()
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btniniciar_Click(object sender, EventArgs e)
        {
            FrmLogin cre = new FrmLogin();
            cre.Show();
            this.Hide();
        }
    }
}
