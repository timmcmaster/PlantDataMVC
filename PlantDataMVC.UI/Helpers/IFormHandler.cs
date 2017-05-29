using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.UI.Helpers
{
    public interface IFormHandler<T>
    {
        void Handle(T form);
    }
}
