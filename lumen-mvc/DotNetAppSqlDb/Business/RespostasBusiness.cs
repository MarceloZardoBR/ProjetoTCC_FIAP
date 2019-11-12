using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotNetAppSqlDb.Business
{
    public class RespostasBusiness
    {

        MyDatabaseContext db = new MyDatabaseContext();

        public IList<CursoModel> ResultadoCursos(ResultadoModel resultadoModel)
        {
            IList<CursoModel> cursos = new List<CursoModel>();

            if (resultadoModel.Categoria1 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(1)).ToList();
            }
            if (resultadoModel.Categoria2 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(2)).ToList();
            }
            if(resultadoModel.Categoria3 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(3)).ToList();
            }
            if(resultadoModel.Categoria4 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(4)).ToList();
            }
            if(resultadoModel.Categoria5 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(5)).ToList();
            }
            if(resultadoModel.Categoria6 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(6)).ToList();
            }
            if(resultadoModel.Categoria1 >= 2 && resultadoModel.Categoria2 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(1) && model.IdCategoria.Equals(2))
                    .Take<CursoModel>(2)
                    .ToList();
            }
            else if (resultadoModel.Categoria2 >= 2 && resultadoModel.Categoria3 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(2) && model.IdCategoria.Equals(3))
                    .Take<CursoModel>(2)
                    .ToList();
            }
            else if (resultadoModel.Categoria3 >= 2 && resultadoModel.Categoria4 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(3) && model.IdCategoria.Equals(4))
                    .Take<CursoModel>(2)
                    .ToList();
            }
            else if (resultadoModel.Categoria4 >= 2 && resultadoModel.Categoria5 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(4) && model.IdCategoria.Equals(5))
                    .Take<CursoModel>(2)
                    .ToList();
            }
            else if (resultadoModel.Categoria5 >= 2 && resultadoModel.Categoria6 >= 2)
            {
                return cursos = db.Cursos.Where(model => model.IdCategoria.Equals(5) && model.IdCategoria.Equals(6))
                    .Take<CursoModel>(2)
                    .ToList();
            }

            return cursos;
        }

    }
}