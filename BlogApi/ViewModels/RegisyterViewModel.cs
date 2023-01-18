using System.ComponentModel.DataAnnotations;

namespace BlogApi.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatorio")]
        [EmailAddress(ErrorMessage = "O Email é invalido")]
        public string Email { get; set; }
    }
}