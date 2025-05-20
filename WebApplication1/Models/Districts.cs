using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class Districts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "區域編號")]
        public int Id { get; set; }
        public int CountyId { get; set; }
        [JsonIgnore]
        [ForeignKey("CountyId")]
        public virtual Counties Counties { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        public string DistrictName { get; set; }
        [Required]
        [Display(Name = "郵遞區號")]
        [StringLength(5, ErrorMessage = "郵遞區號必須為3碼")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "郵遞區號必須是 3 位數字")]
        public string PostalCode { get; set; }

        [Column (TypeName = "DATETIME")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}