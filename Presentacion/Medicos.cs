using System;
using Entidades;
using LogicaNegocio;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Medicos : Form
    {
        private ClsMedico ObjMedico = null;
        private readonly ClsMedicoLn objMedicoLn = new ClsMedicoLn();

        public Medicos()
        {
            InitializeComponent();
            CargarListaMedicos();
        }

        private void CargarListaMedicos()
        {
            ObjMedico = new ClsMedico();
            objMedicoLn.Index(ref ObjMedico);
            if (ObjMedico.MensajeError == null)
            {
                DvgMedicos.DataSource = ObjMedico.DtResultado;
            }
            else
            {
                MessageBox.Show(ObjMedico.MensajeError, "Mensaje de Error - Médicos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DvgMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DvgMedicos.Columns[e.ColumnIndex].Name == "Editar")
                {
                    ObjMedico = new ClsMedico()
                    {
                        CedulaM = DvgMedicos.Rows[e.RowIndex].Cells["CedulaM"].Value.ToString(),

                    };
                    objMedicoLn.Read(ref ObjMedico);
                    txtCedula.Text = ObjMedico.CedulaM;
                    txtNombre.Text = ObjMedico.NombreM;
                    txtCorreo.Text = ObjMedico.Email;
                    txtEspecializacion.Text = ObjMedico.Especializacion;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ObjMedico = new ClsMedico()
            {
                CedulaM = txtCedula.Text,
                NombreM = txtNombre.Text,
                Email = txtCorreo.Text,
                Especializacion = txtEspecializacion.Text,
            };
            objMedicoLn.Create(ref ObjMedico);

            if (ObjMedico.MensajeError == null)
            {
                MessageBox.Show("El médico: " + ObjMedico.CedulaM + " fue agregado con éxito");
                CargarListaMedicos();
            }
            else
            {
                MessageBox.Show(ObjMedico.MensajeError, "El médico no se agregó", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ObjMedico = new ClsMedico()
            {
                CedulaM = txtCedula.Text,
                NombreM = txtNombre.Text,
                Email = txtCorreo.Text,
                Especializacion = txtEspecializacion.Text,
            };
            objMedicoLn.Update(ref ObjMedico);

            if (ObjMedico.MensajeError == null)
            {
                MessageBox.Show("El médico: " + ObjMedico.CedulaM + " fue actualizado con éxito");
                CargarListaMedicos();
            }
            else
            {
                MessageBox.Show(ObjMedico.MensajeError, "El médico no se actualizó", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ObjMedico = new ClsMedico()
            {
                CedulaM = txtCedula.Text,
            };
            objMedicoLn.Delete(ref ObjMedico);
            if (ObjMedico.MensajeError == null)
            {
                MessageBox.Show("El médico: " + ObjMedico.CedulaM + " fue eliminado con éxito");
                CargarListaMedicos();
            }
            else
            {
                MessageBox.Show(ObjMedico.MensajeError, "El médico no se eliminó", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
