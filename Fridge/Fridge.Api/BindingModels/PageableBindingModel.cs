namespace Fridge.Api.BindingModels
{
    public class PageableBindingModel : IPageableBindingModel
    {
        public int? StartPage { get; set; }

        public int? PageSize { get; set; }

        public string OrderBy { get; set; }
    }
}