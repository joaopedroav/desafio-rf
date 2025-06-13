using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTechSub.Models
{
    [Table("PaymentMethod")]
    public class PaymentMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "'Nome' é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "'Nome' não pode ter mais que 50 caracteres")]
        public string Name { get; set; }
    }
}
