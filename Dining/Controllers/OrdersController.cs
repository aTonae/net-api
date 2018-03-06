using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dining.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dining.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IDictionary<int ,IDictionary<string,int>> Post(int[] itemIds,int[] itemCounts, int tableId, int userId)
        {

            IDictionary<int, IDictionary<string,int>> items = new Dictionary<int, IDictionary<string,int>>();

            for (int i = 0; i < itemIds.Length;i++){

                IDictionary<string, int> item = new Dictionary<string, int>();
                item["itemId"] = itemIds[i];
                item["itemCount"] = itemCounts[i];
                items[i] = item;
               
            }
          

            return items;


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
