using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.UI.Helpers
{
    public interface IFormHandler<T>
    {
        void Handle(T form);
    }
}
