using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevSkill.Shop.Domain.Entities
{
    [Table("SeriLogs")]
    public class SeriLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Message { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? MessageTemplate { get; set; }

        [MaxLength(128)]
        public string? Level { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Exception { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Properties { get; set; }
    }
}
