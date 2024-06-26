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
    public class TipoUsuarioDAO
    {
        string cad_cn = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<TipoUsuario> GetTiposUsuario()
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();

            using (SqlConnection cnx = new SqlConnection(cad_cn))
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("pa_listar_tipousuario", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new TipoUsuario()
                    {
                        IdTpu = dr.GetChar(0),
                        NomTpu = dr.GetString(1)
                    });
                }
            }
            return lista;
        }

        public string InsertarTipoUsuario(TipoUsuario obj)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(cad_cn))
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("pa_insertar_tipousuario", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_TPU", obj.IdTpu);
                    cmd.Parameters.AddWithValue("@NOM_TPU", obj.NomTpu);

                    cmd.ExecuteNonQuery();
                }
                return "El Tipo de Usuario con ID: " + $"{obj.IdTpu}" + " fue agregado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarTipoUsuario(TipoUsuario obj)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(cad_cn))
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("pa_actualizar_tipousuario", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_TPU", obj.IdTpu);
                    cmd.Parameters.AddWithValue("@NOM_TPU", obj.NomTpu);

                    cmd.ExecuteNonQuery();
                }
                return "El Tipo de Usuario con ID: " + $"{obj.IdTpu}" + " fue actualizado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarTipoUsuario(string idTpu)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(cad_cn))
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("pa_eliminar_tipousuario", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_TPU", idTpu);

                    cmd.ExecuteNonQuery();
                }
                return "El Tipo de Usuario con ID: " + $"{idTpu}" + " fue eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}