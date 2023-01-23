using System.ComponentModel.DataAnnotations;

namespace BlogApi.ViewModels.Categorys
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage = "O campo name é obrigatorio")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Esse campo precisa ter no minimo 3 caracteres e no maximo 40")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Slug é obrigatorio")]
        public string Slug { get; set; }
    }
}
