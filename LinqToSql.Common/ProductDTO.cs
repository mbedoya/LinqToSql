using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql.Common
{
    public class ProductDTO
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
