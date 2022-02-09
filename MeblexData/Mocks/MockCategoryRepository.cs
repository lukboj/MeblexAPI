using MeblexData.Interfaces;
using MeblexData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories 
        {
            get {
                return new List<Category>
            {
                new Category{Name = "Stół", Description="Idealny stół do twojej jadalni"},
                new Category{Name = "Łóżko", Description="Wygodne łóżka"}
            };
            }
            
         }
    }
}
