using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class NTransferencia
    {
        public static string TransferirCategorias(int idcategoria, int idGrupoOrigem, int idGrupoDestino)
        {
            try
            {
                DTransferencia transferencia = new DTransferencia();
                string resposta = transferencia.TransferirCategorias(idcategoria, idGrupoOrigem, idGrupoDestino);
                return resposta;
            }
            catch (Exception ex)
            {
                return "Erro na transferência: " + ex.Message;
            }
        }
    }
}
