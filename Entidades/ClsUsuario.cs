using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClsUsuario
    {
        #region Atributos Privados
        private string _email, _password;

        //Atributos para conexión BD
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultado;


        #endregion

        #region Atributos Publicos
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultado { get => _dtResultado; set => _dtResultado = value; }
        #endregion




    }
}
