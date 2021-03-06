    using MeblexData.Interfaces;
using MeblexData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Mocks
{
    public class MockProductRepository : IProductRepository
    {
        private readonly MockCategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Product> Products { get {
                return new List<Product>
                {
                    new Product
                    {
                        Name="Magiczny stolik",
                        Price=300,
                        Lenght=50,
                        Width=50,
                        Height=30,
                        Weight=3,
                        Description="Porządny stolik do wielu zadań",
                        Material="Drewno",
                        Color="Czarny",
                        IsPreferred = false,
                        Category= _categoryRepository.Categories.First()


                    },
                    new Product
                    {
                        Name="Magiczne Łóżko",
                        Price=300,
                        Lenght=50,
                        Width=50,
                        Height=30,
                        Weight=3,
                        Description="Porządne i wygodne",
                        Material="Drewno",
                        Color="Czarny",
                                                IsPreferred = true,

                        Category= _categoryRepository.Categories.Last()


                    },
                    new Product
                    {
                        Name="Elegancki stolik",
                        Price=300,
                        Lenght=50,
                        Width=50,
                        Height=30,
                        Weight=3,
                        Description="Porządny stolik do wielu zadań",
                        Material="Drewno",
                        Color="Czarny",                        IsPreferred = true,

                        Category= _categoryRepository.Categories.First()


                    },
                    new Product
                    {
                        Name="Porzadne łóżko",
                        Price=300,
                        Lenght=50,
                        Width=50,
                        Height=30,
                        Weight=3,
                        Description="Porządny stolik do wielu zadań",
                        Material="Drewno",
                        Color="Czarny",                        IsPreferred = true,

                        Category= _categoryRepository.Categories.Last()


                    },
                    new Product
                    {
                        Name="Kamperski stolik",
                        Price=300,
                        Lenght=50,
                        Width=50,
                        Height=30,
                        Weight=3,
                        Description="Porządny stolik do wielu zadań",
                        Material="Sklejka",
                        Color="Czarny",
                                                IsPreferred = false,

                        Category= _categoryRepository.Categories.First()


                    }   

                };
            } }
        public IEnumerable<Product> PreferredProducts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<List<Category>> Categories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetPrefferedProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productid)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int? productid)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Product Gp(int? id)
        {
            throw new NotImplementedException();
        }

        Task<List<Product>> IProductRepository.GetPrefferedProducts()
        {
            throw new NotImplementedException();
        }

        Task<Product> IProductRepository.GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductRepository.GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
