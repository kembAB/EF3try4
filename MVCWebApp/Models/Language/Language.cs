using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCWebApp.Models.Language
{
    public class Language
    {
        [Key]
        [StringLength(20, MinimumLength = 2)]
        public string LanguageName { get; set; }

        public virtual List<PersonLanguage> PersonLanguages { get; set; }

        public Language()
        {
            PersonLanguages = new List<PersonLanguage>();
        }
    }
}
