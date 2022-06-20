using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCWebApp.Models;
namespace MVCWebApp.Models.Person
{
    public class personproperties
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual City.City City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        // languages a person speaks
        public virtual List<PersonLanguage> PersonLanguages { get; set; }
    }
}
