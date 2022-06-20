using System.Collections.Generic;
namespace MVCWebApp.Models.Language.ViewModels
{
    public class AllLanguagesViewModel
    {
        public IEnumerable<Language> LanguageList { get; set; }
        public LanguageviewModel CreateViewModel { get; set; }
    }
}
