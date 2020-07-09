using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAcessoDatos;

namespace CapaLogicaNegocios
{
    public class ClsAlumno
    {
        //Atributos da table alumnos
        public int m_Dni { get; set; }
        public string m_Apellidos { get; set; }
        public string m_Nombres { get; set; }
        public char m_Sexo { get; set; }
        public DateTime m_FechaNac { get; set; }
        public string m_Direccion { get; set; }

        ClsManejador M = new ClsManejador();// Agregamos referencia a ClsManejador

        //Metodo Registrar alumnos
        public string Registrar_Alumnos()
        {
            String msj = "";            //Declaramos una variable para salida
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                //Pasamos todos los parametros de entrada
                lst.Add(new ClsParametros("@Dni", m_Dni));
                lst.Add(new ClsParametros("@Apellidos", m_Apellidos));
                lst.Add(new ClsParametros("@Nombres", m_Nombres));
                lst.Add(new ClsParametros("@Sexo", m_Sexo));
                lst.Add(new ClsParametros("@FechaNac", m_FechaNac));
                lst.Add(new ClsParametros("@Direccion", m_Direccion));
                //Pasamos tambien el parametro de salida
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                M.Ejecutar_SP("Registrar_Alumnos", lst);

                msj = lst[6].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msj;
        }
        //Metodo para Listado de alumnos
        public DataTable ListadoAlumnos()
        {
            return M.Listado("Listado_Alumno", null);
        }

    }
}
