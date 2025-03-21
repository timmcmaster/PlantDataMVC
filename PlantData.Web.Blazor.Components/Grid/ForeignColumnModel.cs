using System;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public class ForeignColumnModel<TForeignData> where TForeignData : new()
    {
        private readonly string _foreignKeyField;
        private readonly string _foreignKeyValue;
        private readonly string _foreignDataUrl;

        public string ForeignKeyField => _foreignKeyField;
        public string ForeignKeyValue => _foreignKeyValue;
        public string ForeignDataUrl => _foreignDataUrl;

        public ForeignColumnModel(Func<TForeignData, string> foreignKeyField, Func<TForeignData, string> foreignKeyValue, string foreignDataUrl)
        {
            TForeignData sample = new TForeignData();

            _foreignKeyField = foreignKeyField(sample);
            _foreignKeyValue = foreignKeyValue(sample);
            _foreignDataUrl = foreignDataUrl;
        }

    }
}
 
