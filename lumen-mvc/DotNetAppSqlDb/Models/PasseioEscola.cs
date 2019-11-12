using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("passeiosEscolas")]
    public class PasseioEscola
    {
        [Key]
        [Column("id_passeioEscola")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPasseioEscola { get; set; }

        [Column("id_escola")]
        public int idEscola { get; set; }
        
        public virtual Escola Escola { get; set; }

        [Column("id_passeio")]
        public int IdPasseio { get; set; }

        public virtual Passeio Passeio { get; set; }
    }
}