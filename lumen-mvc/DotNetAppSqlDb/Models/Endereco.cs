using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("enderecos")]
    public class Endereco
    {
        [Key]
        [Column("id_end")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEndereco { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }

        [Column("numero")]
        public int Numero { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}