using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoriaRepository
    {
         public List<Categoria> ObterTodos()
        {
            SqlCommand command = Conexao.Conectar();
            command.CommandText = "SELECT * FROM categorias";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            List<Categoria> categorias = new List<Categoria>();
            //for(int i = 0; i < table.Rows.Count; i++)
            //{
            //    DataRow linha = table.Rows[i];
            //}

            foreach(DataRow linha in table.Rows)
                {
                Categoria categoria = new Categoria();
                categoria.Id = Convert.ToInt32(linha["id"]);
                categoria.Nome = linha["nome"].ToString();
                categorias.Add(categoria);
            }
            command.Connection.Close();
            return categorias;

        }
        public int Inserir(Categoria categoria)
        {
            SqlCommand command = Conexao.Conectar();
            command.CommandText = @"INSERT INTO categorias (nome)
OUTPUT INSERTED.ID
VALUES (@NOME)";
            command.Parameters.AddWithValue("@NOME", categoria.Nome);
        }


    }


}
