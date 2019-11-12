using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("passeiosAlunos")]
    public class PasseioAluno
    {
        [Key]
        [Column("id_passeioAluno")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPasseioAluno { get; set; }

        [Column("id_autorizacao")]
        public int IdAutorizacao { get; set; }

        [NotMapped]
        public virtual Autorizacao Autorizacao { get; set; }

        [Column("id_passeio")]
        public int IdPasseio { get; set; }

        [NotMapped]
        public virtual Passeio Passeio { get; set; }

        //[NotMapped]
        //public IList<PasseioAluno> ListaPasseioAluno { get; set; }
        
    }
}