using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTechSub.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "'Nome' é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "'Nome' não pode ter mais que 50 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "'Email' é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "'Email' não pode ter mais que 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "'Senha' é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "'Senha' não pode ter mais que 50 caracteres")]
        public string Password { get; set; }

        public Guid? PaymentMethodId { get; set; }

        [Required(ErrorMessage = "'Assinatura ativa' é um campo obrigatório")]
        public bool IsSubscriptionActive { get; set; }

        [Required(ErrorMessage = "'Trial' é um campo obrigatório")]
        public bool IsTrialExpired { get; set; }
    }
}
