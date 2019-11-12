using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper;
using System.Linq;
using System.Web;
using CsvHelper.Configuration.Attributes;

namespace DotNetAppSqlDb.Models
{
    [Table("alunos")]
    public class Aluno
    {
        [Key]
        [Column("id_aluno")]
        [Ignore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAluno { get; set; }

        [Column("nome_completo")]
        [Required(ErrorMessage = "Nome obrigatório")]
        [Name("nome completo", "nome", "Nome completo", "Nome", "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Column("senha")]
        [Required(ErrorMessage = "Senha obrigatório")]
        [Ignore]
        public string Senha { get; set; }

        [NotMapped]
        [Ignore]
        public string SenhaAtual { get; set; }

        [NotMapped]
        [Ignore]
        public string SenhaPassada { get; set; }

        [Column("primeiroAcesso")]
        [Ignore]
        public Boolean PrimeiroAcesso { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Email obrigatório")]
        [Name("email", "e-mail", "E-mail", "E-Mail")]
        public string Email { get; set; }

        [Column("telefone")]
        [Required(ErrorMessage = "Telefone obrigatório")]
        [Name("tel", "Tel", "Telefone", "telefone")]
        public string Telefone { get; set; }

        [Column("sexo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Name("genero", "Genero")]
        public String Genero { get; set; }

        [Column("Turma")]
        [Name("turma", "Turma")]
        public String Turma { get; set; }

        [Column("id_escola")]
        public int? IdEscola { get; set; }

        [NotMapped]
        [Ignore]
        public String[] Generos = new [] {"Masculino", "Feminino", "Indefinido"};
    }
}