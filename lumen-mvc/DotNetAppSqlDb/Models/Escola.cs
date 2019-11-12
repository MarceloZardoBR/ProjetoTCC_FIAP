using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("escolas")]
    public class Escola
    {
        public Escola()
        {
            this.Alunos = new List<Aluno>();
            this.Planos = new List<Plano>();
        }
        [Key]
        [Column("id_escola")]
        public int IdEscola { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("id_end")]
        public int IdEndereco { get; set; }
        [NotMapped]
        public int y { get; set; }
        [NotMapped]
        public string label { get; set; }
        [NotMapped]
        public virtual Endereco Endereco { get; set; }

        public List<Plano> Planos { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}