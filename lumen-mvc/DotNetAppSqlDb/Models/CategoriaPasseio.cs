using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("categoriaPasseio")]
    public class CategoriaPasseio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idCategoria")]
        public int IdCategoria { get; set; }

        [Column("nomeCategoria")]
        public string NomeCategoria { get; set; }

    }
}