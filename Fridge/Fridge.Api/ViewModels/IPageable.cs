using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fridge.Api.ViewModels
{
    public class PageableViewModel<T>
    {
        public int NumItems { get; set; }
        public int NumPages { get; set; }
        public T Result { get; set; }
    }
}