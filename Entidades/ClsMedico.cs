using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClsMedico
    {
        #region Atributos Privados

        private string _cedulaM, _nombreM;
        private string _email, _especializacion;

        // Atributos para conexión BD
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultado;

        #endregion

        #region Atributos Públicos

        public string CedulaM { get => _cedulaM; set => _cedulaM = value; }
        public string NombreM { get => _nombreM; set => _nombreM = value; }
        public string Email { get => _email; set => _email = value; }
        public string Especializacion { get => _especializacion; set => _especializacion = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultado { get => _dtResultado; set => _dtResultado = value; }

        #endregion
    }
}
