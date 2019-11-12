using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("area_curso")]
    public class CursoModel
    {
        [Key]
        [Column("idCurso")]
        public int IdCurso { get; set; }
        [Column("nomeCurso")]
        public String NomeCurso { get; set; }
        
        [Column("idCategoria")]
        public int IdCategoria { get; set; }

        public virtual CategoriaModel CategoriaModel { get; set; }
        
    }
}