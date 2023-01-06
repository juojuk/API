using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNET_Baigiamasis.Models
{
    [Table("Roles")]
    public class Role
    {
        public Role()
        {
        }
        public Role(int id, string member)
        {
            Id = id;
            Member = member;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Member { get; set; }

        public List<Person> Persons { get; set; }
    }

}
