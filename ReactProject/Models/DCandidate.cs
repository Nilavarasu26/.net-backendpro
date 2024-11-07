using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactProject.Models
{
    public class DCandidate
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }

        public int Age { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmailId { get; set; }
    }
}
