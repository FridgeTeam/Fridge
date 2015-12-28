namespace Fridge.Api.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentsBindingModel : IPageableBindingModel
    {
        public string OrderBy { get; set; }

        public int? PageSize { get; set; }

        public int? StartPage { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string RecipeName { get; set; }
    }
}