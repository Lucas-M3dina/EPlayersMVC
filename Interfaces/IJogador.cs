using System.Collections.Generic;
using MVC_Eplayers.Models;

namespace MVC_Eplayers.Interfaces
{
    public interface IJogador
    {
         void Criar(Jogador j);
         List<Jogador> LerTodos();
         void Alterar (Jogador j);
         void Deletar(int id);


         
    }
}