namespace Fridge.Api.BindingModels
{
    public interface IPageableBindingModel
    {
        int? StartPage { get; set; }

        int? PageSize { get; set; }

        string OrderBy { get; set; }
    }
}