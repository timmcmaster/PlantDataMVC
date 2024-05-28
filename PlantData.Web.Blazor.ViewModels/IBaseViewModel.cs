using Microsoft.AspNetCore.Components;

namespace PlantData.Web.Blazor.ViewModels
{
    public interface IBaseViewModel
    {
        NavigationManager NavMan { get; }
    }
}