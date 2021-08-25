using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using MMTShop.Models;

namespace MMTShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        DataAccessLayer db = new DataAccessLayer();

        //GET: api/Product
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            try 
            {
                DataTable dt = db.GetData("SP_GetAllProducts", "");
                if (dt.Rows.Count > 0)
                {
                    List<Product> result = (from row in dt.Select()
                              select new Product
                              {
                                  SKU = Convert.ToInt32(row["SKU"]),
                                  Name = Convert.ToString(row["Name"]),
                                  Description = Convert.ToString(row["Description"]),
                                  Price = Convert.ToString(row["Price"]) + "GBP",
                                  CategoryName = Convert.ToString(row["CategoryName"])
                              }).ToList();
                              
                    return result;
                }
                else
                {
                    return Enumerable.Empty<Product>();
                }
            }
            catch (Exception e) 
            {
                throw e;
            }
        }

        //GET: api/Product/{category}
        [HttpGet("{category}")]
        public IEnumerable<Product> Get(string category)
        {
            try
            {
                DataTable dt = db.GetData("SP_GetProductByCategory", category);
                if (dt.Rows.Count > 0)
                {
                    List<Product> result = (from row in dt.Select()
                                            select new Product
                                            {
                                                SKU = Convert.ToInt32(row["SKU"]),
                                                Name = Convert.ToString(row["Name"]),
                                                Description = Convert.ToString(row["Description"]),
                                                Price = Convert.ToString(row["Price"]) + "GBP",
                                                CategoryName = Convert.ToString(row["CategoryName"])
                                            }).ToList();

                    return result;
                }
                else
                {
                    return Enumerable.Empty<Product>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //GET: api/Product/Featured
        [HttpGet("Featured")]
        public IEnumerable<Product> Get()
        {
            try
            {
                DataTable dt = db.GetData("SP_GetFeaturedProducts", "");
                if (dt.Rows.Count > 0)
                {
                    List<Product> result = (from row in dt.Select()
                                            select new Product
                                            {
                                                SKU = Convert.ToInt32(row["SKU"]),
                                                Name = Convert.ToString(row["Name"]),
                                                Description = Convert.ToString(row["Description"]),
                                                Price = Convert.ToString(row["Price"]) + "GBP",
                                                CategoryName = Convert.ToString(row["CategoryName"])
                                            }).ToList();

                    return result;
                }
                else
                {
                    return Enumerable.Empty<Product>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
