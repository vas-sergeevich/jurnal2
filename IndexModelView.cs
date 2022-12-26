using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pagen.Models.Identity;

namespace Pagen.Models.Pagination
{
    public class IndexModelView<TModel>
    {
        public List<TModel> Items { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}