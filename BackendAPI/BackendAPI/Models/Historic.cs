using BackendAPI.Models.Enums;

namespace BackendAPI.Models
{
    public class Historic
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime ServiceDate { get; set; }
        public ServiceType ServiceType { get; set; }
        public Receipt Receipt { get; set; }

        public Historic(int id, string? description, DateTime serviceDate, ServiceType serviceType, Receipt receipt)
        {
            Id = id;
            Description = description;
            ServiceDate = serviceDate;
            ServiceType = serviceType;
            Receipt = receipt;
        }
    }
}
