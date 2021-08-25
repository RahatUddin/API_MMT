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
    public class CategoryController : ControllerBase
    {
        DataAccessLayer db = new DataAccessLayer();

        //GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            try
            {
                DataTable dt = db.GetData("SP_GetAllCategories", "");
                if (dt.Rows.Count > 0)
                {
                    List<Category> result = (from row in dt.Select()
                                             select new Category
                                             {
                                                 ID = Convert.ToInt32(row["ID"]),
                                                 Name = Convert.ToString(row["Name"]),
                                             }).ToList();
                    return result;
                }
                else
                {
                    return Enumerable.Empty<Category>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
