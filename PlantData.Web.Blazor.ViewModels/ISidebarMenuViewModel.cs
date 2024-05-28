using System.Threading.Tasks;

namespace PlantData.Web.Blazor.ViewModels
{
    public interface ISidebarMenuViewModel : IBaseViewModel
    {
        string DockWidth { get; set; }
        MenuViewModel Menu { get; set; }
        string TargetCss { get; set; }
        string Width { get; set; }

        Task InitialiseAsync();
    }
}