using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translator.Models;

namespace Translator.Data
{
    public class TranslatorContext: DbContext
    {
        public TranslatorContext(DbContextOptions<TranslatorContext> opt): base(opt)
        {

        }

        public DbSet<Translate> Translator { get; set; }
    }
}
