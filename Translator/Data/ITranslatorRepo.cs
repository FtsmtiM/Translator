using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translator.Models;

namespace Translator.Data
{
    public interface ITranslatorRepo
    {
        bool SaveChanged();
        IEnumerable<Translate> GetAllTranslators();
        Translate GetTranslateById(int id);
        void CreateTranslate(Translate translate);

        void UpdateTranslate(Translate translate);
        void DeleteTranslate(Translate translate);
    }
}
