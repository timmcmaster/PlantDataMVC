using Microsoft.AspNetCore.Components;

namespace PlantData.Web.Blazor.UIModels.ViewModels
{
    public interface IBaseViewModel
    {
        NavigationManager NavMan { get; }
    }
}