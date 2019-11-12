using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("categorias")]
    public class CategoriaModel
    {
        [Key]
        [Column("idCategoria")]
        public int IdCategoria { get; set; }
        [Column("nomeCategoria")]
        public String NomeCategoria { get; set; }


    }
}