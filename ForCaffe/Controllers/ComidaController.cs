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
    public class ComidaController : Controller
    {

        //  private const string TitleCrud = "Comida";

        // GET: Comida
        public ActionResult Index()
        {
            //string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ssd\\source\\repos\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf;Integrated Security=True";
            string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jaqueline.correia\\Downloads\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf";
            SqlConnection conexao = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Comida", conexao);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            conexao.Open();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
            conexao.Close();

            var tableList = new List<Comida> { };
            int numRows;
            numRows = ds.Tables["Table"].Rows.Count;
            for (int i = 0; i < numRows; i++)
            {
                int tblID = ds.Tables["Table"].Rows[i].Field<int>("Id");
                string tblTipo = ds.Tables["Table"].Rows[i].Field<string>("Tipo");
                string tblTamanho = ds.Tables["Table"].Rows[i].Field<string>("Tamanho");
                float tblPreco = ds.Tables["Table"].Rows[i].Field<float>("Preco");

                tableList.Add(new Comida()
                {
                    Id = tblID,
                    Tipo = tblTipo,
                    Tamanho = tblTamanho,
                    Preco = tblPreco
                });
            }

            return View(tableList);
            //return View();
        }

        // GET: Comida/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comida/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comida/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                // TODO: Add insert logic here
                string tmpTipo = collection.GetValues("Tipo")[0];
                string tmpTamanho = collection.GetValues("Tamanho")[0];
                string tmpPreco = collection.GetValues("Preco")[0];
                //string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ssd\\source\\repos\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf;Integrated Security=True";
                string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jaqueline.correia\\Downloads\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf";
                SqlConnection conexao = new SqlConnection(strcon);
                string commandText = "Insert into [Comida] (Tipo, Tamanho, Preco) VALUES " +
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

        // GET: Comida/Edit/5
        public ActionResult Edit(int id = 0)
        {
            return View(id);
        }

        // POST: Comida/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            // TODO: Add update logic here
                return View();
        }

 
        // GET: Comida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comida/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ssd\\source\\repos\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf;Integrated Security=True";
                string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jaqueline.correia\\Downloads\\ForCaffe\\ForCaffe\\App_Data\\BancoForCaffe.mdf";
                SqlConnection conexao = new SqlConnection(strcon);
                string commandText = "Delete from [Comida] WHERE Id=" + id + ";";
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
