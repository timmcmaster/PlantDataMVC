using Microsoft.AspNetCore.Components;

namespace PlantData.Web.Blazor.UIModels.ViewModels
{
    public class BaseViewModel : IBaseViewModel
    {
        public NavigationManager NavMan { get; private set; }

        public BaseViewModel(NavigationManager navMan)
        {
            NavMan = navMan;
        }
    }
}
