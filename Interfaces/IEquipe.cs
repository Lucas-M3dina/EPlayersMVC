using System.Collections.Generic;
using MVC_Eplayers.Models;

namespace MVC_Eplayers.Interfaces
{
    public interface IEquipe
    {
        void Criar(Equipe e);

        List<Equipe> LerTodas();

        void Alterar(Equipe e);

        void Deletar(int id);
    }
}