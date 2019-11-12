using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("usuario_id")]
        public int IdUsuario { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("id_escola")]
        public int IdEscola { get; set; }

        
        public virtual Escola  Escola {get; set;}

        [Column("id_empresa")]
        public int IdEmpresa { get; set; }

        public Empresa  Empresa {get; set; }
    }
}