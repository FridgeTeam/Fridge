namespace Fridge.Api.ViewModels
{
    using Common.Mapping;
    using Fridge.Models;

    public class CategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}