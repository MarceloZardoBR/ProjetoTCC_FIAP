using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("resultado")]
    public class ResultadoModel
    {
        [Key]
        [Column("idResultado")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResposta { get; set; }

        [Column("id_aluno")]
        public int IdAluno { get; set; }

        [Column("categoria1")]
        public int Categoria1 { get; set; }

        [Column("categoria2")]
        public int Categoria2 { get; set; }

        [Column("categoria3")]
        public int Categoria3 { get; set; }

        [Column("categoria4")]
        public int Categoria4 { get; set; }

        [Column("categoria5")]
        public int Categoria5 { get; set; }

        [Column("categoria6")]
        public int Categoria6 { get; set; }

        public virtual Aluno Aluno { get; set; }
    }

}