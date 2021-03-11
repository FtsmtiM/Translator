using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translator.Models;

namespace Translator.Data
{
    public class SqlTranslatorRepo : ITranslatorRepo
    {
        private readonly TranslatorContext _context;

        public SqlTranslatorRepo(TranslatorContext context)
        {
            _context = context;
        }

        public void CreateTranslate(Translate translate)
        {
            if(translate == null)
            {
                throw new ArgumentNullException(nameof(translate));
            }

            _context.Translator.Add(translate);
        }

        public void DeleteTranslate(Translate translate)
        {
            if (translate == null)
            {

                throw new NotImplementedException(nameof(translate));
            }
            _context.Remove(translate);
        }

        public IEnumerable<Translate> GetAllTranslators()
        {
            return _context.Translator.ToList();
        }

        public Translate GetTranslateById(int id)
        {
            return _context.Translator.FirstOrDefault(t=>t.Id==id);
        }

        public bool SaveChanged()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTranslate(Translate translate)
        {
        }
    }
}
