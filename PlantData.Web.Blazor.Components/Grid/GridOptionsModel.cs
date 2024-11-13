using System.Collections.Generic;

namespace PlantData.Web.Blazor.SharedComponents.Grid
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

        public static GridOptionsModel Default
        {
            get
            {
                return new GridOptionsModel
                {
                    AllowAdd = true,
                    AllowEdit = true,
                    AllowDelete = true,
                    AllowPaging = true,
                    AllowSorting = true
                };
            }
        }

        public static GridOptionsModel ViewOnly
        {
            get
            {
                return new GridOptionsModel
                {
                    AllowAdd = false,
                    AllowEdit = false,
                    AllowDelete = false,
                    AllowPaging = false,
                    AllowSorting = false
                };
            }
        }

        public static GridOptionsModel NoPagingOrSorting
        {
            get
            {
                return new GridOptionsModel
                {
                    AllowAdd = true,
                    AllowEdit = true,
                    AllowDelete = true,
                    AllowPaging = false,
                    AllowSorting = false
                };
            }
        }
    }
}
