using System;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DTransferencia
    {
        public string TransferirCategorias(int idCategoria, int idGrupoOrigem, int idGrupoDestino)
        {
            string resp = "";

            using (SqlConnection sqlCon = new SqlConnection(Conexao.Cn))
            {
                try
                {
                    sqlCon.Open();

                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandText = "sp_transferir_categoria"; // Nome do procedimento armazenado
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parIdCategoria = new SqlParameter("@idcategoria", System.Data.SqlDbType.Int);
                        parIdCategoria.Value = idCategoria;
                        sqlCmd.Parameters.Add(parIdCategoria);

                        SqlParameter parIdGrupoOrigem = new SqlParameter("@idGrupoOrigem", System.Data.SqlDbType.Int);
                        parIdGrupoOrigem.Value = idGrupoOrigem;
                        sqlCmd.Parameters.Add(parIdGrupoOrigem);

                        SqlParameter parIdGrupoDestino = new SqlParameter("@idGrupoDestino", System.Data.SqlDbType.Int);
                        parIdGrupoDestino.Value = idGrupoDestino;
                        sqlCmd.Parameters.Add(parIdGrupoDestino);

                        // Executar o comando
                        int rowsAffected = sqlCmd.ExecuteNonQuery();

                        resp = rowsAffected > 0 ? "Categoria transferida com sucesso" : "Nenhuma categoria transferida";
                    }
                }
                catch (Exception ex)
                {
                    resp = "Erro: " + ex.Message;
                }
            }

            return resp;
        }
    }
}
