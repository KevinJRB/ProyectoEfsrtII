using ProyectoEFSRT.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoEFSRT.DAO
{
    public class UsuariosDAO
    {
        string cad_cn = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection cnx = new SqlConnection(cad_cn))
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("pa_listar_usuario", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Usuario()
                    {
                        CodUs = dr.GetString(0),
                        NomUs = dr.GetString(1),
                        CtrUs = dr.GetString(2),
                        IdTpu = dr.GetChar(3),
                        EstUs = dr.GetString(4),
                        CorUs = dr.GetString(5)
                    });
                }
            }
            return lista;
        }

        public string InsertarUsuario(Usuario obj)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(cad_cn))
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("pa_insertar_usuario", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_US", obj.CodUs);
                    cmd.Parameters.AddWithValue("@NOM_US", obj.NomUs);
                    cmd.Parameters.AddWithValue("@CTR_US", obj.CtrUs);
                    cmd.Parameters.AddWithValue("@ID_TPU", obj.IdTpu);
                    cmd.Parameters.AddWithValue("@EST_US", obj.EstUs);
                    cmd.Parameters.AddWithValue("@COR_US", obj.CorUs);

                    cmd.ExecuteNonQuery();
                }
                return "El Usuario con Código: " + $"{obj.CodUs}" + " fue agregado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarUsuario(Usuario obj)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(cad_cn))
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("pa_actualizar_usuario", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_US", obj.CodUs);
                    cmd.Parameters.AddWithValue("@NOM_US", obj.NomUs);
                    cmd.Parameters.AddWithValue("@CTR_US", obj.CtrUs);
                    cmd.Parameters.AddWithValue("@ID_TPU", obj.IdTpu);
                    cmd.Parameters.AddWithValue("@EST_US", obj.EstUs);
                    cmd.Parameters.AddWithValue("@COR_US", obj.CorUs);

                    cmd.ExecuteNonQuery();
                }
                return "El Usuario con Código: " + $"{obj.CodUs}" + " fue actualizado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarUsuario(string codUs)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(cad_cn))
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("pa_eliminar_usuario", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_US", codUs);

                    cmd.ExecuteNonQuery();
                }
                return "El Usuario con Código: " + $"{codUs}" + " fue eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
