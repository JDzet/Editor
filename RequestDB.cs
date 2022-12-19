using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using По_новой.Model;
using По_новой.Properties;

namespace По_новой
{
    internal class RequestDB
    {
        DemoMainEntities context = new DemoMainEntities();

        public User GetUser(string log, string pass)
        {
            var user = context.User.FirstOrDefault(x => x.Login == log && x.Password == pass);
            return user;
        }

        public List<object[]> GetProduct(List<Product>pr)
        {
            
            List<object[]> data = new List<object[]>();

            foreach (var x in pr)
            {
                data.Add(new object[4]);

                data[data.Count - 1][0] = x.ProductId;
                if (x.Photo == "")
                    data[data.Count - 1][1] = Resources.picture;
                else
                    data[data.Count - 1][1] = Resources.ResourceManager.GetObject(x.Photo.ToString());
                data[data.Count - 1][2] = $"{x.Name}\nКатегория: {x.Category.CategoryName}" +
                    $"Описание: {x.Description}\nЦена: {x.Price}";
                data[data.Count - 1][3] = x.Articule;
            }
            return data;
        }

        public List<Category> GetCategory() 
        {
            var cate = context.Category.ToList();
            return cate;
        }

    }
}
