using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DGrupo
    {
        private int _Idgrupo;
        private string _Nome;
        private List<DCategoria> _Categorias;

        public int Idgrupo
        {
            get { return _Idgrupo; }
            set { _Idgrupo = value; }
        }

        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        // Construtor vazio
        public DGrupo()
        {
        }

        // Construtor com parâmetros
        public DGrupo(int idgrupo, string nome)
        {
            this.Idgrupo = idgrupo;
            this.Nome = nome;
        }

        public string InserirGrupo(DGrupo Grupo)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // Configurar a conexão
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                // Configurar o comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserirgrupo"; // Nome do procedimento armazenado
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parâmetro para o nome do grupo
                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Grupo.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParIdgrupo = new SqlParameter();
                ParIdgrupo.ParameterName = "@idgrupo";
                ParIdgrupo.SqlDbType = SqlDbType.Int;
                ParIdgrupo.Value = Grupo.Idgrupo;
                SqlCmd.Parameters.Add(ParIdgrupo);

                //Executar o comando

                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi Inserido";


            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }
    }
}
