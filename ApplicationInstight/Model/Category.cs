using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationInstight.Model
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int MaLoai { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string TenLoai {get; set; }

    }
}
