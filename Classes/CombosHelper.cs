using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Classes
{
    public class CombosHelper : IDisposable
    {
        private static EcommerceContext db = new EcommerceContext();
        public static List<Departaments> GetDepartaments() {

        var dep = db.Departaments.ToList();
        dep.Add(new Departaments
            {
                DepartamentsId = 0,
                Name = "[Selecione um departamento!]"
            });

            return dep = dep.OrderBy(d => d.Name).ToList();
}

        public static List<City> GetCities(int departamentId)
        {

            var dep = db.Cities.Where(c => c.DepartamentsId == departamentId).ToList();
            dep.Add(new City
            {
                CityId = 0,
                Name = "[Selecione uma cidade!]"
            });

            return dep = dep.OrderBy(d => d.Name).ToList();
        }

        public static List<Company> GetCompanys()
        {

            var comp = db.Companies.ToList();
            comp.Add(new Company
            {
                CompanyId = 0,
                Name = "[ Selecione uma Companhia ]"
            });

            return comp = comp.OrderBy(c => c.Name).ToList();

        }

        public static List<Category> GetCategories(int companyId)
        {

            var cat = db.Categories.Where(c => c.CompanyId == companyId).ToList();
            cat.Add(new Category
            {
                CategoryId = 0,
                Description = "[Selecione uma categoria!]"
            });

            return cat = cat.OrderBy(c => c.Description).ToList();
        }

        public static List<Tax> GetTaxes(int companyId)
        {

            var tax = db.Taxes.Where(c => c.CompanyId == companyId).ToList();
            tax.Add(new Tax
            {
                TaxId = 0,
                Description = "[Selecione uma Taxa!]"
            });

            return tax = tax.OrderBy(c => c.Description).ToList();
        }

        public static List<Customer> GetCustomer(int companyId)
        {

            var customer = db.Customers.Where(c => c.CompanyId == companyId).ToList();
            customer.Add(new Customer
            {
                CustomerId = 0,
                FirstName = "[Selecione um Cliente!]"
            });

            return customer = customer.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();
        }

        public static List<Product> GetProducts(int companyId)
        {

            var product = db.Products.Where(c => c.CompanyId == companyId).ToList();
            product.Add(new Product
            {
                ProductId = 0,
                Description = "[Selecione um Produto!]"
            });

            return product = product.OrderBy(c => c.Description).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}