using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Models
{
    public class Translate
    {
        public int Id { get; set; }
        [Required] 
        [MaxLength(250)]
        public string TigrinaWord { get; set; }

        [Required]
        public string EnglishWord { get; set; }
        public string Desctiption { get; set; }
    }
}
