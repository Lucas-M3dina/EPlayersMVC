using System;
using System.Collections.Generic;
using System.IO;
using MVC_Eplayers.Interfaces;

namespace MVC_Eplayers.Models
{
    public class Equipe:EPlayersBase, IEquipe
    {
        public int IdEquipe { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";


        public Equipe(){
            CriarPastaEArquivo(PATH);
        }

        private string Preparar(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Alterar(Equipe e)
        {
            List<string> linhas = LerTodasLinhasCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(Preparar(e));
            ReescreverCSV(PATH, linhas);
        }

        public void Criar(Equipe e)
        {
            string[] linha = {Preparar(e)};
            File.AppendAllLines(PATH, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(PATH, linhas);
        }

        public List<Equipe> LerTodas()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();

                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }

            return equipes;
        }
    }
}