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
    public class ProdutosPersonalizadosController : Controller
    {
        // GET: ProdutosPersonalizados
        public ActionResult Index()
        {
            //string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ssd\\source\\repos\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf;Integrated Security=True";
            string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jaqueline.correia\\Downloads\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf";
            SqlConnection conexao = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ProdutosPersonalizados", conexao);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            conexao.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
            conexao.Close();

            var tableList = new List<ProdutosPersonalizados> { };
            int numRows;
            numRows = ds.Tables["Table"].Rows.Count;
            for (int i = 0; i < numRows; i++)
            {
                int tblID = ds.Tables["Table"].Rows[i].Field<int>("Id");
                string tblTipo = ds.Tables["Table"].Rows[i].Field<string>("Tipo");
                float tblPreco = ds.Tables["Table"].Rows[i].Field<float>("Preco");

                tableList.Add(new ProdutosPersonalizados()
                {
                    Id = tblID,
                    Tipo = tblTipo,
                    Preco = tblPreco
                });
            }

            return View(tableList);

            //return View();
        }

        // GET: ProdutosPersonalizados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutosPersonalizados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutosPersonalizados/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string tmpTipo = collection.GetValues("Tipo")[0];
                string tmpPreco = collection.GetValues("Preco")[0];
                //string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ssd\\source\\repos\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf;Integrated Security=True";
                string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jaqueline.correia\\Downloads\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf";
                SqlConnection conexao = new SqlConnection(strcon);
                string commandText = "Insert into [ProdutosPersonalizados] (Tipo, Preco) VALUES " +
                    "('" + tmpTipo + "','" + tmpPreco + ")";
                SqlCommand cmd = new SqlCommand(commandText, conexao);
                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosPersonalizados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutosPersonalizados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosPersonalizados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutosPersonalizados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ssd\\source\\repos\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf;Integrated Security=True";
                string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jaqueline.correia\\Downloads\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf";
                SqlConnection conexao = new SqlConnection(strcon);
                string commandText = "Delete from [ProdutosPersonalizados] WHERE Id=" + id + ";";
                SqlCommand cmd = new SqlCommand(commandText, conexao);
                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
