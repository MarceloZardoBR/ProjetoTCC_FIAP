using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("datas_disponiveis")]
    public class DataDisponivel
    {
        [Key]
        [Column("id_data_disponivel")]
        public int IdDataDisponivel { get; set; }

        public string IsDeleted { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Data { get; set; }

        [Column("qtd_alunos")]
        public int QtdAlunos { get; set; }
        
        [Column("id_empresa")]
        public int IdEmpresa { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}