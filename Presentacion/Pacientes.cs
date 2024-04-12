using Entidades;
using LogicaNegocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Pacientes : Form
    {
        private ClsPaciente ObjPaciente = null;
        private readonly ClsPacienteLn objPacienteln = new ClsPacienteLn();
        public Pacientes()
        {
            InitializeComponent();
            CargarListaPacientes();
        }

        private void CargarListaPacientes()
        {
            ObjPaciente = new ClsPaciente();
            objPacienteln.Index(ref ObjPaciente);
            if (ObjPaciente.MensajeError == null)
            {
                DvgPacientes.DataSource = ObjPaciente.DtResultado;
            }
            else
            {
                MessageBox.Show(ObjPaciente.MensajeError,"Mensajer Error Paciente",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            ObjPaciente = new ClsPaciente()
            {
                CedulaP = txtCedula.Text,
                NombreP = txtNombre.Text,
                Email = txtCorreo.Text,
                Eps = txtEps.Text,
            };
            objPacienteln.Create(ref ObjPaciente);

            if (ObjPaciente.MensajeError == null)
            {
                MessageBox.Show("El paciente: " + ObjPaciente.CedulaP + " fue agregado con éxito");
                CargarListaPacientes();
            }
            else
            {
                MessageBox.Show(ObjPaciente.MensajeError,"El paciente no se agrego",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void DvgPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DvgPacientes.Columns[e.ColumnIndex].Name == "Editar")
                {
                    ObjPaciente = new ClsPaciente()
                    {
                        CedulaP= DvgPacientes.Rows[e.RowIndex].Cells["CedulaP"].Value.ToString(),

                    };
                    objPacienteln.Read(ref ObjPaciente);
                    txtCedula.Text = ObjPaciente.CedulaP;
                    txtNombre.Text = ObjPaciente.NombreP;
                    txtCorreo.Text = ObjPaciente.Email;
                    txtEps.Text = ObjPaciente.Eps;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ObjPaciente = new ClsPaciente()
            {
                CedulaP = txtCedula.Text,
                NombreP = txtNombre.Text,
                Email = txtCorreo.Text,
                Eps = txtEps.Text,
            };
            objPacienteln.Update(ref ObjPaciente);

            if (ObjPaciente.MensajeError == null)
            {
                MessageBox.Show("El paciente: " + ObjPaciente.CedulaP + " fue actualizado con éxito");
                CargarListaPacientes();
            }
            else
            {
                MessageBox.Show(ObjPaciente.MensajeError, "El paciente no se actualizó", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ObjPaciente = new ClsPaciente()
            {
                CedulaP = txtCedula.Text,
             };
            objPacienteln.Delete(ref ObjPaciente);
            if (ObjPaciente.MensajeError == null)
            {
                MessageBox.Show("El paciente: " + ObjPaciente.CedulaP + " fue eliminado con éxito");
                CargarListaPacientes();
            }
            else
            {
                MessageBox.Show(ObjPaciente.MensajeError, "El paciente no se eliminó", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
