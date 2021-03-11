using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translator.Models;

namespace Translator.Data
{
    public class MockTranslatorRepo : ITranslatorRepo
    {
        public void CreateTranslate(Translate translate)
        {
            throw new NotImplementedException();
        }

        public void DeleteTranslate(Translate translate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Translate> GetAllTranslators()
        {
            var translate = new List<Translate>
            {
                new Translate { Id = 1, TigrinaWord = "በጊዕ", EnglishWord = "Sheep", Desctiption = "a domesticated ruminant mammal with a thick woolly coat. It is kept in flocks for its wool or meat." },
                new Translate { Id = 2, TigrinaWord = "ጣውላ", EnglishWord = "Table", Desctiption = "a piece of furniture with a flat top and one or more legs." },
                new Translate { Id = 3, TigrinaWord = "አራንቺ", EnglishWord = "Orange", Desctiption = "a large round juicy citrus fruit with a tough bright reddish-yellow rind." },
                new Translate { Id = 4, TigrinaWord = "ማንካ", EnglishWord = "Spoon", Desctiption = "shallow oval or round bowl on a long handle, used for eating, stirring, and serving food." },

            };
            return translate;
        }
    

        public Translate GetTranslateById(int id)
        {
            return new Translate { Id = 1, TigrinaWord = "በጊዕ", EnglishWord = "Sheep", Desctiption = "a domesticated ruminant mammal with a thick woolly coat. It is kept in flocks for its wool or meat." };
        }

        public bool SaveChanged()
        {
            throw new NotImplementedException();
        }

        public void UpdateTranslate(Translate translate)
        {
            throw new NotImplementedException();
        }
    }
}
