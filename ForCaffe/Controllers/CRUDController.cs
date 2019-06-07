using ForCaffe.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForCaffe.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public class ComidaRepository : AbstractRepository<Comida, int>
        {
            ///<summary>Exclui uma pessoa pela entidade
            ///<param name="entity">Referência de Pessoa que será excluída.</param>
            ///</summary>
            public override void Delete(Comida entity)
            {
                using (var conn = new SqlConnection(StringConnection))
                {
                    string sql = "DELETE Comida Where Id=@Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", entity.Tipo);
                    cmd.Parameters.AddWithValue("@Id", entity.Tamanho);
                    cmd.Parameters.AddWithValue("@Id", entity.Preco);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

            public override void DeleteById(int id)
            {
                throw new NotImplementedException();
            }



            ///<summary>Obtém todas as comidas
            ///<returns>Retorna as pessoas cadastradas.</returns>
            ///</summary>
            public override List<Comida> GetAll()
            {
                string sql = "Select Tamanho, Tipo, Preco FROM Comida ORDER BY Tipo";
                using (var conn = new SqlConnection(StringConnection))
                {
                    var cmd = new SqlCommand(sql, conn);
                    List<Comida> list = new List<Comida>();
                    Comida p = null;
                    try
                    {
                        conn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                p = new Comida();
                                p.Tipo = reader["Tipo"].ToString();
                                p.Tamanho = reader["Tamanho"].ToString();
                                p.Preco = (float)reader["Preco"];
                                list.Add(p);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    return list;
                }
            }

            public override Comida GetById(int id)
            {
                throw new NotImplementedException();
            }

            ///<summary>Obtém uma pessoa pelo ID
            ///<param name="id">Id do registro que obtido.</param>
            ///<returns>Retorna uma referência de Pessoa do registro encontrado ou null se ele não for encontrado.</returns>
            ///</summary>
            //public override Comida GetById(int id)
            //{
            //    using (var conn = new SqlConnection(StringConnection))
            //    {
            //        string sql = "Select Id, Nome, Email, Cidade, Endereco FROM Pessoa WHERE Id=@Id";
            //        SqlCommand cmd = new SqlCommand(sql, conn);
            //        cmd.Parameters.AddWithValue("@Id", id);
            //        Pessoa p = null;
            //        try
            //        {
            //            conn.Open();
            //            using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            //            {
            //                if (reader.HasRows)
            //                {
            //                    if (reader.Read())
            //                    {
            //                        p = new Pessoa();
            //                        p.Id = (int)reader["Id"];
            //                        p.Nome = reader["Nome"].ToString();
            //                        p.Email = reader["Email"].ToString();
            //                        p.Cidade = reader["Cidade"].ToString();
            //                        p.Endereco = reader["Endereco"].ToString();
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            throw e;
            //        }
            //        return p;
            //    }
            //}

            ///<summary>Salva a pessoa no banco
            ///<param name="entity">Referência de Pessoa que será salva.</param>
            ///</summary>
            public override void Save(Comida entity)
            {
                using (var conn = new SqlConnection(StringConnection))
                {
                    string sql = "INSERT INTO Comida (Tamanho, Tipo, Preco) VALUES (@Tamanho, @Tipo, @Preco)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Tamanho", entity.Tamanho);
                    cmd.Parameters.AddWithValue("@Tipo", entity.Tipo);
                    cmd.Parameters.AddWithValue("@Preco", entity.Preco);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }


            ///<summary>Atualiza a pessoa no banco
            ///<param name="entity">Referência de Pessoa que será atualizada.</param>
            ///</summary>
            public override void Update(Comida entity)
            {
                using (var conn = new SqlConnection(StringConnection))
                {
                    string sql = "UPDATE Comida SET Tipo=@Tipo, Tamanho=@Tamanho, Preco=@Preco Where Id=@Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Tipo", entity.Tipo);
                    cmd.Parameters.AddWithValue("@Tamanho", entity.Tamanho);
                    cmd.Parameters.AddWithValue("@Preco", entity.Preco);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

        }
    }
}