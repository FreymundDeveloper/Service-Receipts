using BackendAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Historic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ServiceDate { get; set; }
        public ServiceType ServiceType { get; set; }
        public Receipt Receipt { get; set; }

        public Historic() { }

        public Historic(string? description, DateTime serviceDate, ServiceType serviceType, Receipt receipt)
        {
            Description = description;
            ServiceDate = serviceDate;
            ServiceType = serviceType;
            Receipt = receipt;
        }
    }
}
