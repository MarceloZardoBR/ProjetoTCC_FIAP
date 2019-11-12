using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("areas")]
    public class Area
    {
        [Key]
        [Column("id_area")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArea { get; set; }
        
        [Column("nome_area")]
        public string NomeArea { get; set; }
      
    }
}