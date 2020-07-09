using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAcessoDatos
{
    public class ClsManejador
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DemoNCapas;Integrated Security=True");

        //Metodo para abrir a conexion
        public void abrir_conexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }
        //Metodo para cerrar a conexion
        public void cerrar_conexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }
        //Metodo para ejecutar sp (Insert, Delete, Update)
        public void Ejecutar_SP(String Nombre_SP, List<ClsParametros> lst)
        {
            SqlCommand cmd;
            try
            {
                abrir_conexion();
                cmd = new SqlCommand(Nombre_SP, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                        }
                        if (lst[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamano).Direction = ParameterDirection.Output;
                        }
                    }
                    cmd.ExecuteNonQuery();

                    //Recupera parametros de salida
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                            lst[i].Valor = cmd.Parameters[i].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cerrar_conexion();
            }
        }

        //Metodo para los listado o consulta de datos (select)
        public DataTable Listado(string Nombre_SP, List<ClsParametros> lst)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter(Nombre_SP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if(lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
