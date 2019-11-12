using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("NETLOG")]
    public class Log
    {
        [Key]
        [Column("IDLOG")]
        public int IdLog { get; set; }

        [Column("DATALOG")]
        public DateTime DataLog { get; set; }

        [Column("CAMINHO")]
        public String Caminho { get; set; }

        [Column("ORIGEM"), DefaultValue("Não Informado")]
        public String Origem { get; set; }
    }
}