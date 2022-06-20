namespace MVCWebApp.Models
{
    public class PersonLanguage
    {
        public int PersonId { get; set; }
        public virtual Person.personproperties Person { get; set; }

        public string LanguageName { get; set; }
        public virtual Language.Language Language { get; set; }
    }
}
