using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class GridOptionsModel
    {
        public bool AllowAdd { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowPaging { get; set; }
        public bool AllowSorting { get; set; }

        public List<string> ToolbarItems 
        {  
            get
            {
                var list = new List<string>();

                if (AllowAdd)
                    list.Add("Add");
                if (AllowEdit)
                    list.Add("Edit");
                if (AllowDelete)
                    list.Add("Delete");
                if (AllowEdit)
                    list.AddRange(new List<string>() { "Update", "Cancel" });

                return list;
            }
        }
    }
}
