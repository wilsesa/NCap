using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAcessoDatos
{
    public class ClsParametros
    {
        //Declarar todos los Parametros
        public String Nombre { get; set; }
        public Object Valor { get; set; }
        public SqlDbType TipoDato { get; set; }
        public int Tamano { get; set; }
        public ParameterDirection Direccion { get; set; }


        //Declarar los constructores
        //C.Entrada
        public ClsParametros(string objNombre, object objValor)
        {
            Nombre = objNombre;
            Valor = objValor;
            Direccion = ParameterDirection.Input;
        }

        //C.Salida
        public ClsParametros(string objNombre, SqlDbType objTipoDato, Int32 objTamano)
        {
            Nombre = objNombre;
            TipoDato = objTipoDato;
            Tamano = objTamano;
            Direccion = ParameterDirection.Output;
        }
        

    }
}
