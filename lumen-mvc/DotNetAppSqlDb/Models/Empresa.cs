using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("empresas")]
    public class Empresa
    {
        public Empresa()
        {
            this.Datas = new List<DataDisponivel>();
        }
        [Key]
        [Column("id_empresa")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }

        [Column("nome_empresa")]
        public string NomeEmpresa { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("Senha")]
        public string Senha { get; set; }

        [Column("id_area")]
        public int IdArea { get; set; }

        [NotMapped]
        public Area Area { get; set; }

        [Column("id_end")]
        public int IdEndereco { get; set; }

        [NotMapped]
        public Endereco Endereco { get; set; }

        [NotMapped]
        public string label { get; set; }

        [NotMapped]
        public double y { get; set; }

        [NotMapped]
        public virtual List<Passeio> Passeios { get; set; }

        public List<DataDisponivel> Datas { get; set; }
    }
}
