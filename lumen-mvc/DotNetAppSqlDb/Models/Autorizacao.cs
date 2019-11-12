using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("autorizacoes")]
    public class Autorizacao
    {
        [Key]
        [Column("id_autorizacao")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAutorizacao { get; set; }

        [Column("url")]
        public string URL { get; set; }

        [Column("id_aluno")]
        public int IdAluno { get; set; }

        public virtual Aluno Aluno { get; set; }
    }
}