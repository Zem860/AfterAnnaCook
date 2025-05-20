using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class FormData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        [Display(Name = "營業人名稱")]
        public string BusinessName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "統一編號必須是 8 碼")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "統一編號只能是 8 位數字")]
        [Display(Name = "營利事業統一編號")]
        public string TaxId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        [Display(Name = "負責人姓名")]
        public string ResponsiblePersonName { get; set; }
        [Column(TypeName = "nvarchar")]
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "身分證字號必須為 10 碼")]
        [RegularExpression(@"^[A-Z]{1}[12]{1}\d{8}$", ErrorMessage = "格式錯誤，範例：A123456789")]
        public string PersonalId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(3)]
        [Display(Name = "郵遞區號")]
        public string BusinessPostalCode { get; set; }
        [Required]
        [Display(Name = "縣市Id")]
        public int BusinessCountyId { get; set; }
        [JsonIgnore]
        [ForeignKey("BusinessCountyId")]
        public virtual Counties BusinessCounty { get; set; }
        [Required]
        [Display(Name = "區域Id")]

        public int BusinessDistrictId { get; set; }
        [JsonIgnore]
        [ForeignKey("BusinessDistrictId")]
        public virtual Districts BusinessDistrict { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(30)]
        [Display(Name ="營業詳細地址")]
        public string BusinessAddress { get; set; }
        [Required]
        [Display(Name = "申報方式")]
        public int ReportTypeId { get; set; }
        [JsonIgnore]
        [ForeignKey("ReportTypeId")]
        public virtual ReportType ReportType { get; set; }

        [Display(Name = "起始年")]
        public int StartYear { get; set; }
        [Display(Name = "起始月")]
        public int startMonth { get; set; }

        [Required]
        [Display(Name = "其他說明")]
        public int OtherId { get; set; }
        [JsonIgnore]
        [ForeignKey("OtherId")]
        public virtual Others Other { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        [Display(Name = "聯絡人姓名")]
        public string ContactPersonName { get; set; }
        [RegularExpression(@"^0\d{1,2}-\d{6,8}$", ErrorMessage = "電話格式錯誤（例：02-23456789）")]
        public string ContactPhone { get; set; }

        [RegularExpression(@"^09\d{8}$", ErrorMessage = "手機格式錯誤（例：0912345678）")]
        public string ContactCellPhone { get; set; }

        [RegularExpression(@"^\d{1,5}$", ErrorMessage = "分機最多 5 碼")]
        public string ContactExt { get; set; }

        [Required]
        [Display(Name ="是否等同營業地址")]
        public bool IsSameAsBusinessAddress { get; set; } = false;

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(3)]
        [Display(Name = "郵遞區號")]
        public string ContactPostalCode { get; set; }
        [Required]
        [Display(Name = "縣市Id")]
        public int ContactCountyId { get; set; }
        [JsonIgnore]
        [ForeignKey("ContactCountyId")]
        public virtual Counties ContactCounty { get; set; }
        [Required]
        [Display(Name = "區域Id")]

        public int ContactDistrictId { get; set; }
        [JsonIgnore]
        [ForeignKey("ContactDistrictId")]
        public virtual Districts ContactDistrict { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(30)]
        [Display(Name = "通訊詳細地址")]
        public string ContactAddress { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(30)]
        [Display(Name = "聯絡人Email")]
        public string ContactEmail { get; set; }

    }
}