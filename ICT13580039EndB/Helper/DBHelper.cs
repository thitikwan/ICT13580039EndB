using System;
using System.Collections.Generic;
using ICT13580039EndB.Models;
using SQLite;

namespace ICT13580039EndB.Helper
{
    public class DBHelper
    {
        SQLiteConnection db;

        public DBHelper(string dbPath){
            db = new SQLiteConnection(dbPath);

            db.CreateTable<Product>();
        }
        public int AddProduct (Product product){
            db.Insert(product);
            return product.Id;
        }

        public List <Product> GetProduct(){
            return db.Table<Product>().ToList();
        }

        public int DeleteProduct(Product product){
            return db.Delete(product);
        }

        internal object UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
