using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DotNetAppSqlDb.Models
{
    
    [Table("passeios")]
    public class Passeio
    {
        //public Passeio()
        //{
        //    this.Confirmado = false;
        //}
        [Column("confirmado")]
        public Boolean Confirmado { get; set; }
        [Key]
        [Column("id_passeio")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPasseio { get; set; }

        [Column("nome")]
        public String Nome { get; set; }

        [Column("data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Column("qtdAlunos")]
        public int QuantAlunos { get; set; }

        [Column("id_escola")]
        public int? IdEscola { get; set; }

        [Column("id_empresa")]
        public int IdEmpresa { get; set; }

        [Column("valor")]
        public double Valor { get; set; }

        [Column("idCategoria")]
        public int IdCategoria { get; set; }

        [Column("passeioRealizado")]
        public Boolean PasseioRealizado { get; set; }

        public virtual CategoriaPasseio CategoriaPasseio { get; set; }

        
        public virtual Escola Escola { get; set; }

        [Column("id_data_disponivel")]
        public int IdDataDisponivel { get; set; }

        public virtual DataDisponivel DataDisponivel { get; set; }

        public List<Aluno> Alunos { get; set; }

        public List<Passeio> ListaPasseio { get; set; }

        public string label { get; set;}

        public int y { get; set;}
        

    }
}