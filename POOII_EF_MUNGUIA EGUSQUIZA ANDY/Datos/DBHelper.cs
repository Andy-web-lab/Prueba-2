using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DBHelper
    {
        private static string cad_cn =
            ConfigurationManager.ConnectionStrings["cn1"]
                                .ConnectionString;

        public static void EjecutarSP(string nombreSP,
                       params object[] valoresparametros)
        {
            using (SqlConnection cnx = new SqlConnection(cad_cn))
            {
                cnx.Open(); // abrir la conexión            
                using (SqlCommand cmd = new SqlCommand(nombreSP, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // si hay valores para los parámetros
                    if (valoresparametros.Length > 0)
                    { 
                        // llamando al método PoblarParametros
                        PoblarParametros(cmd, valoresparametros);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // para la instrucción SELECT
        public static DataTable RetornaDataTable(string nombreSP,
                      params object[] valoresparametros)
        {
            DataTable tabla = new DataTable();
            //
            using (SqlDataAdapter adap = new SqlDataAdapter(
                                nombreSP,cad_cn))
            {
                adap.SelectCommand.Connection.Open(); // abrir la cnx

                adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                // si hay valores para los parámetros
                if (valoresparametros.Length > 0 )
                {
                    PoblarParametros(
                        adap.SelectCommand, valoresparametros);
                }
                // poblar el datatable
                adap.Fill(tabla);
            }
            //
            return tabla;
        }


        public static void EjecutarSP_Trx(string nombreSP,
                       params object[] valoresparametros)
        {
            SqlConnection cnx = new SqlConnection(cad_cn);
            cnx.Open(); // abrir la conexión            
            SqlTransaction trx = cnx.BeginTransaction();
            // try - catch
            try
            {
                using (SqlCommand cmd = new SqlCommand(nombreSP, cnx, trx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // si hay valores para los parámetros
                    if (valoresparametros.Length > 0)
                    {
                        // llamando al método PoblarParametros
                        PoblarParametros(cmd, valoresparametros);
                    }
                    cmd.ExecuteNonQuery(); // aqui puede haber un error
                    // pero si no hubo error, entonces confirmamos la
                    // operación
                    trx.Commit();
                }
            }
            catch (Exception ex)
            {
                // si hubo error, entonces cancelamos la transacción
                trx.Rollback();
                throw new Exception(ex.Message);
            }
            finally {
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
            }
        }

        private static void PoblarParametros(SqlCommand cmd, 
                       params object[] valoresparametros)
        { 
            int indice = 0;
            // descubrir y crear los paámetros del procedimiento
            // almacenado que será ejecutado el SqlCommand enviado.
            // Requisito: debe haber una conexión abierta con la BD
            SqlCommandBuilder.DeriveParameters(cmd);
            // recorrer la coleccion de parámetros del SqlCommand
            foreach (SqlParameter prm in cmd.Parameters)
            {
                if (prm.ParameterName != "@RETURN_VALUE")
                {
                    prm.Value = valoresparametros[indice];
                    indice++;
                }
            }
        }


    }
}