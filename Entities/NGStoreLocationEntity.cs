using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emes.Entities
{

    [Table("NGStoreLocations")]
    public class NGStoreLocationEntity

    {
        [Key]
        public int NGstoreLocationID { get; set; }

        [Required]
        [StringLength(255)]
        public required string Name { get; set; }

    }
}
