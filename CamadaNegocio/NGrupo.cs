using System;
using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
    public class NGrupo
    {
        // Método Inserir
        public static string Inserir(string nome)
        {
            DGrupo Obj = new DGrupo();
            Obj.Nome = nome;
            return Obj.InserirGrupo(Obj);
        }

        // Outros métodos de edição, exclusão, busca etc. podem ser adicionados aqui
    }
}

