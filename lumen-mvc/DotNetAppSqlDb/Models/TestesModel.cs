using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("teste")]
    public class TestesModel
    {
        [Key]
        [Column("idTeste")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTeste { get; set; }

        [Column("idCurso")]
        public int IdCurso { get; set; }

        public virtual CursoModel CursoModel { get; set; }

        [Column("idResultado")]
        public int IdResultado { get; set; }

        public virtual ResultadoModel ResultadoModel { get; set; }

        [Column("id_aluno")]
        public int IdAluno { get; set; }

        public virtual Aluno Aluno { get; set; }

    }

    }