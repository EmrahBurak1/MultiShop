using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public class ResultCategoryDto //Frontend içerisine oluşturduğumuz bu dto katmanıyla verileri frontend tarafına taşıyacağız.
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
