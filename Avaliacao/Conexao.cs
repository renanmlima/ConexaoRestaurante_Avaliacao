using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao
{
    public class Conexao
    {
        static private string server = "localhost";
        static private string database = "bd_avaliacao";
        static private string usuario = "root";
        static private string senha = "cursoads";

        static public string strConn = $"server={server}; " +
            $"User Id={usuario}; database={database}; " +
            $"password={senha}";

        MySqlConnection cn;

        public bool Conectar()
        {
            bool result;
            try
            {
                cn = new MySqlConnection(strConn);
                cn.Open();
                result = true;

            }
            catch
            {
                result = false;
            }
            return result;
        }

        public void Desconectar()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }


        public bool Executa(string sql)
        {
            bool resultado;
            Conectar();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, cn); //A LINHA EM QUESTÃO ESTÁ CRIANDO UM OBJETO DA CLASSE MYSQLCOMMAND, DE NOME COMANDO, ESSA  CLASSE RECEBE DOIS PARAMETROS
                comando.ExecuteNonQuery();
                resultado = true;
            }
            catch
            {
                resultado = false;
            }
            finally
            {
                Desconectar();
            }

            return resultado;
        }
        public DataTable Retorna(string sql)
        {
            Conectar();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable data = new DataTable();
                da.Fill(data);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
