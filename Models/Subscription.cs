using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTechSub.Models
{
    [Table("Subscription")]
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid SubscriptionPlanId { get; set; }

        [Required]
        public decimal SubscriptionValue { get; set; }

        [Required]
        public DateTime ChargeDate { get; set; }
        
        [Required]
        public bool IsCanceled { get; set; }
    }
}
