using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Business
{
    public class TesteBusiness
    {
        CursoDAO cursoDAO = new CursoDAO();

        public String EscolhasDoTeste(FrasesModel model)
        {
            //verificando se o valor boolean do checkbox foi marcado como TRUE, caso marcado ele salva em um nova LISTA
            var perguntaMarcada = model.ListaFrases.Where(x => x.Selecionado == true);
            String idRespostas;
            //criando a lista tipo String
            IList<string> listaCategoria = new List<string>();
            //Gerando o Json da lista com os valores marcado pelo usuario
            string json = JsonConvert.SerializeObject(perguntaMarcada);
            //Transformando o Json em um Array de Json
            var objJson = JArray.Parse(json);

            foreach (JObject o in objJson)
            {
                //Acessando somente a propriedade IdCategoria e adcionando na lista
                listaCategoria.Add(o["IdPergunta"].ToString());
            }

            idRespostas = JsonConvert.SerializeObject(listaCategoria);
            return idRespostas;
        }

        //Calculando Respostas do Usuario
        public ResultadoModel ResultadoTeste(String escolhasTeste, Aluno alunoModel)
        {
            var objJson = JArray.Parse(escolhasTeste);

            int[] realista= { 1, 0 };
            int[] investigativo= { 2, 0 };
            int[] artistico= { 3, 0 };
            int[] social= { 4, 0 };
            int[] empreendedor= { 5, 0 };
            int[] convencional= { 6, 0 };

            foreach (var itens in objJson)
            {

                if (itens.ToObject<int>() == 1)
                {
                    realista[1]++;
                }
                if (itens.ToObject<int>() == 2)
                {
                    realista[1]++;
                }
                if (itens.ToObject<int>() == 3)
                {
                    realista[1]++;
                }
                if (itens.ToObject<int>() == 4)
                {
                    realista[1]++;
                }
                if (itens.ToObject<int>() == 5)
                {
                    investigativo[1]++;
                }
                if (itens.ToObject<int>() == 6)
                {
                    investigativo[1]++;
                }
                if (itens.ToObject<int>() == 7)
                {
                    investigativo[1]++;
                }
                if (itens.ToObject<int>() == 8)
                {
                    investigativo[1]++;
                }
                if (itens.ToObject<int>() == 9)
                {
                    artistico[1]++;
                }
                if (itens.ToObject<int>() == 10)
                {
                    artistico[1]++;
                }
                if (itens.ToObject<int>() == 11)
                {
                    artistico[1]++;
                }
                if (itens.ToObject<int>() == 12)
                {
                    artistico[1]++;
                }
                if (itens.ToObject<int>() == 13)
                {
                    social[1]++;
                }
                if (itens.ToObject<int>() == 14)
                {
                    social[1]++;
                }
                if (itens.ToObject<int>() == 15)
                {
                    social[1]++;
                }
                if (itens.ToObject<int>() == 16)
                {
                    social[1]++;
                }
                if (itens.ToObject<int>() == 17)
                {
                    empreendedor[1]++;
                }
                if (itens.ToObject<int>() == 18)
                {
                    empreendedor[1]++;
                }
                if (itens.ToObject<int>() == 19)
                {
                    empreendedor[1]++;
                }
                if (itens.ToObject<int>() == 20)
                {
                    empreendedor[1]++;
                }
                if (itens.ToObject<int>() == 21)
                {
                    convencional[1]++;
                }
                if (itens.ToObject<int>() == 22)
                {
                    convencional[1]++;
                }
                if (itens.ToObject<int>() == 23)
                {
                    convencional[1]++;
                }
                if (itens.ToObject<int>() == 24)
                {
                    convencional[1]++;
                }
            }

            ResultadoDAO resultadoDao = new ResultadoDAO();

            ResultadoModel model = new ResultadoModel
            {
                IdAluno = alunoModel.IdAluno,
                Categoria1 = realista[1],
                Categoria2 = investigativo[1],
                Categoria3 = artistico[1],
                Categoria4 = social[1],
                Categoria5 = empreendedor[1],
                Categoria6 = convencional[1],
            };

            resultadoDao.Inserir(model);

            return model;
        }
        
        
    }
}
