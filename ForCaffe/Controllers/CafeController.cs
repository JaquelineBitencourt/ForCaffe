using ForCaffe.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForCaffe.Controllers
{
    public class CafeController : Controller
    {
        // GET: Cafe
        public ActionResult Index()
        {
            //string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ssd\\source\\repos\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf;Integrated Security=True";
            string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jaqueline.correia\\Downloads\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf";
            SqlConnection conexao = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Cafe", conexao);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            conexao.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
            conexao.Close();

            var tableList = new List<Cafe> { };
            int numRows;
            numRows = ds.Tables["Table"].Rows.Count;
            for (int i = 0; i < numRows; i++)
            {
                int tblID = ds.Tables["Table"].Rows[i].Field<int>("Id");
                string tblTipo = ds.Tables["Table"].Rows[i].Field<string>("Tipo");
                string tblTamanho = ds.Tables["Table"].Rows[i].Field<string>("Tamanho");
                float tblPreco = ds.Tables["Table"].Rows[i].Field<float>("Preco");

                tableList.Add(new Cafe()
                {
                    Id = tblID,
                    Tipo = tblTipo,
                    Tamanho = tblTamanho,
                    Preco = tblPreco
                });
            }

            String URL2 = "http://10.200.118.60:8081/cafes";
            using (var webClient = new System.Net.WebClient())
            {
                var json2 = webClient.DownloadString(URL2);
                var itens = new List<Cafe>();
                JsonConvert.PopulateObject(json2, itens);
                for (int i = 0; i < tableList.Count(); i++)
                {
                    for (int j = 0; j < itens.Count(); j++)
                    {

                        if (itens[j].Tipo == tableList[i].Tipo)
                        {
                            if (itens[j].Preco >= tableList[i].Preco)
                            {
                                tableList[i].Preco = itens[j].Preco;
                            }
                            else
                            {
                                tableList[i].Preco = itens[j].Preco * Convert.ToSingle(0.9);
                            }
  
                        }
                       
                    }
                   
                }
            }

            return View(tableList);
        }

        // GET: Cafe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cafe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cafe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
            // TODO: Add insert logic here
            string tmpTipo = collection.GetValues("Tipo")[0];
            string tmpTamanho = collection.GetValues("Tamanho")[0];
            string tmpPreco = collection.GetValues("Preco")[0];
            // string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ssd\\source\\repos\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf;Integrated Security=True";
            string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jaqueline.correia\\Downloads\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf";
            SqlConnection conexao = new SqlConnection(strcon);
            string commandText = "Insert into [Cafe] (Tipo, Tamanho, Preco) VALUES " +
                "('" + tmpTipo + "','" + tmpTamanho + "', " + tmpPreco + ")";
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
        

        // GET: Cafe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cafe/Edit/5
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

        // GET: Cafe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cafe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
             try
             {
                // TODO: Add delete logic here
                //string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ssd\\source\\repos\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf;Integrated Security=True";
                string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jaqueline.correia\\Downloads\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf";
                SqlConnection conexao = new SqlConnection(strcon);
                string commandText = "Delete from [Cafe] WHERE Id=" + id + ";";
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

        public ActionResult Contato()
        {
            return View();
        }
    }
}

