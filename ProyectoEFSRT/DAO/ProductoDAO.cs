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
   

        public class ProductosDAO
        {
            string cad_cn = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

            public List<Producto> GetProductos()
            {
                List<Producto> lista = new List<Producto>();

                using (SqlConnection cnx = new SqlConnection(cad_cn))
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("pa_listar_producto", cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new Producto()
                        {
                            CodProd = dr.GetString(0),
                            NomProd = dr.GetString(1),
                            DescProd = dr.GetString(2),
                            PreProd = dr.GetDecimal(3),
                            StkProd = dr.GetInt32(4)
                        });
                    }
                }
                return lista;
            }

            public string InsertarProducto(Producto obj)
            {
                try
                {
                    using (SqlConnection cnx = new SqlConnection(cad_cn))
                    {
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand("pa_insertar_producto", cnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@COD_PROD", obj.CodProd);
                        cmd.Parameters.AddWithValue("@NOM_PROD", obj.NomProd);
                        cmd.Parameters.AddWithValue("@DESC_PROD", obj.DescProd);
                        cmd.Parameters.AddWithValue("@PRE_PROD", obj.PreProd);
                        cmd.Parameters.AddWithValue("@STK_PROD", obj.StkProd);

                        cmd.ExecuteNonQuery();
                    }
                    return "El Producto con Código: " + $"{obj.CodProd}" + " fue agregado correctamente";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            public string ActualizarProducto(Producto obj)
            {
                try
                {
                    using (SqlConnection cnx = new SqlConnection(cad_cn))
                    {
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand("pa_actualizar_producto", cnx);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@COD_PROD", obj.CodProd);
                        cmd.Parameters.AddWithValue("@NOM_PROD", obj.NomProd);
                        cmd.Parameters.AddWithValue("@DESC_PROD", obj.DescProd);
                        cmd.Parameters.AddWithValue("@PRE_PROD", obj.PreProd);
                        cmd.Parameters.AddWithValue("@STK_PROD", obj.StkProd);

                        cmd.ExecuteNonQuery();
                    }
                    return "El Producto con Código: " + $"{obj.CodProd}" + " fue actualizado correctamente";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            public string EliminarProducto(string codProd)
            {
                try
                {
                    using (SqlConnection cnx = new SqlConnection(cad_cn))
                    {
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand("pa_eliminar_producto", cnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@COD_PROD", codProd);

                        cmd.ExecuteNonQuery();
                    }
                    return "El Producto con Código: " + $"{codProd}" + " fue eliminado correctamente";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
