using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("planos")]
    public class Plano
    {
        [Key]
        [Column("id_plano")]
        public int IdPlano { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("valor")]
        public float Valor { get; set; }

        public List<Escola> Escolas { get; set; }

    }
}