using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Dtos
{
    public class TranslateReadDto
    {
        public int Id { get; set; }
        public string TigrinaWord { get; set; }
        public string EnglishWord { get; set; }
     
    }
}
