using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    [Table("frases")]
    public class FrasesModel
    {
        [Key]
        [Column("idFrase")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPergunta { get; set; }
        [Column("frase")]
        public String Pergunta { get; set; }
        
        [Column("idCategoria")]
        public int IdCategoria { get; set; }

        public virtual CategoriaModel CategoriaModel { get; set; }

        public bool Selecionado { get; set; }

        public IList<FrasesModel> ListaFrases { get; set; }

        //gerando o curso de acordo com as respostas
    }

}