using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace DotNetAppSqlDb.Models
{
    [Table("pagamento")]
    public class Pagamento
    {
        [Key]
        [Column("id_pagamento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPagamento { get; set; }

        [Column("titular")]
        public string Titular { get; set; }

        [Column("numero_cartao")]
        public string NumeroCartao { get; set; }

        [Column("validade")]
        public string Validade { get; set; }

        [Column("codigo")]
        public string Codigo { get; set; }

        [Column("id_escola")]
        public int IdEscola { get; set; }

        public virtual Escola Escola { get; set; }

    }
}