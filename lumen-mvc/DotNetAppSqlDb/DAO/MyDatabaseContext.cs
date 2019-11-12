using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class MyDatabaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyDatabaseContext() : base("name=MyDbConnection")
        {
        
        }

        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<ResultadoModel> Resultado { get; set; }
        public DbSet<TestesModel> Testes { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<FrasesModel> Frases { get; set; }
        public DbSet<Log> Log { get; set; }
        
        public DbSet<Area> Area { get; set; }

        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<Plano> Plano { get; set; }

        public DbSet<Aluno> Aluno { get; set; }

        public DbSet<Autorizacao> Autorizacao { get; set; }

        public DbSet<DataDisponivel> DataDisponivel { get; set; }

        public DbSet<Escola> Escola { get; set; }

        public DbSet<Passeio> Passeio { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<PasseioAluno> PasseioAluno { get; set; }

        public DbSet<PasseioEscola> PasseioEscola { get; set; }

        public DbSet<Pagamento> Pagamento { get; set;}
        public DbSet<CategoriaPasseio> CategoriaPasseio { get; set; }

    }
}
