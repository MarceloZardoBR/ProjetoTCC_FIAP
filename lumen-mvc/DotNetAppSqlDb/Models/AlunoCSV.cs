using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper.Configuration.Attributes;

namespace DotNetAppSqlDb.Models
{
    public class AlunoCSV
    {
        [Name("nome_aluno", "Nome Aluno")]
        public string NomeCompleto { get; set; }

        
        //[Name("email", "Email", "e-mail", "E-mail")]
        [Ignore]
        public string Email { get; set; }

        
        //[Name("telefone", "Telefone")]
        [Ignore]
        public string Telefone { get; set; }

        
        //[Name("genero", "Genero", "sexo", "Sexo")]
        [Ignore]
        public string Genero { get; set; }
    }
}