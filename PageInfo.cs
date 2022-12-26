using System;

namespace Pagen.Models.Pagination
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } = 10; // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
            => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}