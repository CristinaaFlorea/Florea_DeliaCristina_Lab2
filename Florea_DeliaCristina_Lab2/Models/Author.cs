using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Florea_DeliaCristina_Lab2.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Book>? Books { get; set; } //navigation property
    }
}