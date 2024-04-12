using AccesoDatos.DataBase;
using Entidades;
using System.Data;

namespace LogicaNegocio
{
    public class ClsMedicoLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Método Index
        public void Index(ref ClsMedico objMedico)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Index]",
                Scalar = false,
            };
            Ejecutar(ref objMedico);
        }

        private void Ejecutar(ref ClsMedico objMedico)
        {
            ObjDataBase.CRUD(ref ObjDataBase);
            if (ObjDataBase.MensajeErrorOS == null) //Si es null no hay error
            {
                if (ObjDataBase.Scalar)
                {
                    objMedico.ValorScalar = ObjDataBase.ValorScalar; //Tipo valor escalar
                }
                else
                {
                    objMedico.DtResultado = ObjDataBase.DsResultados.Tables[0];
                    //Validar si la tabla tiene un solo registro
                    if (objMedico.DtResultado.Rows.Count == 1)
                    {
                        foreach (DataRow item in objMedico.DtResultado.Rows)
                        {
                            objMedico.CedulaM = item["cedulaM"].ToString();
                            objMedico.NombreM = item["nombreM"].ToString();
                            objMedico.Email = item["email"].ToString();
                            objMedico.Especializacion = item["especializacion"].ToString();
                        }
                    }
                }
            }
            else
            {
                objMedico.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }
        #endregion

        #region CRUD Médico

        public void Create(ref ClsMedico objMedico)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Create]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaM", "15", objMedico.CedulaM);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreM", "15", objMedico.NombreM);
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "15", objMedico.Email);
            ObjDataBase.DtParametros.Rows.Add(@"@Especializacion", "15", objMedico.Especializacion);
            Ejecutar(ref objMedico);
        }

        public void Update(ref ClsMedico objMedico)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Update]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaM", "15", objMedico.CedulaM);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreM", "15", objMedico.NombreM);
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "15", objMedico.Email);
            ObjDataBase.DtParametros.Rows.Add(@"@Especializacion", "15", objMedico.Especializacion);
            Ejecutar(ref objMedico);
        }

        public void Delete(ref ClsMedico objMedico)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Delete]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaM", "15", objMedico.CedulaM);
            Ejecutar(ref objMedico);
        }

        public void Read(ref ClsMedico objMedico)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Read]",
                Scalar = false,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaM", "15", objMedico.CedulaM);
            Ejecutar(ref objMedico);
        }

        #endregion

        #region Métodos Privados

        #endregion
    }
}
