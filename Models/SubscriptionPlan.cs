using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTechSub.Models
{
    [Table("SubscriptionPlan")]
    public class SubscriptionPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "'Nome' é um campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "'Valor mensal' é um campo obrigatório")]
        public decimal MonthlyPrice { get; set; }

        [Required(ErrorMessage = "'Valor anual' é um campo obrigatório")]
        public decimal AnualPrice { get; set; }

        [Required(ErrorMessage = "'Permite Teste' é um campo obrigatório")]
        public bool AllowTrial { get; set; }
    }
}
