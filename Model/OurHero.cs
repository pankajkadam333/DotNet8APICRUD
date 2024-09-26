using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotNet8API.Model
{
    public class OurHero
    {
        public OurHero()
        {
            isActive = true;
        }
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; } 
    }
}
