using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dining.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<IDictionary<string, string>> Get()
        {
            string outputMessage = null;
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<IDictionary<string, string>> itemList = new List<IDictionary<string, string>>();


            connetionString =
                "user id=android;" +
                "password=android123;server=184.168.194.70;" +

                "database=androidhotel; " +
            "connection timeout=30";
            cnn = new SqlConnection(connetionString);
            cmd = new SqlCommand();

            try
            {
                cnn.Open();
                cmd.CommandText = "SELECT TOP 10 * FROM dbo.RMenuMst";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cnn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IDictionary<string, string> items = new Dictionary<string, string>();

                    items["id"] = ((int)reader.GetValue(0)).ToString();
                    items["title"] = (string)reader.GetValue(1);
                    items["unit"] = (string)reader.GetValue(5);
                    items["category"] = (string)reader.GetValue(10);
                    items["price"] = "100";
                    itemList.Add(items);







                }

                outputMessage = "Connection Open";
                cnn.Close();
            }
            catch (Exception ex)
            {
                outputMessage = "Cannot Connect to server" + ex;

            }

            return itemList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<object> Get(int id)
        {
            IDictionary<string, object> dict1 = new Dictionary<string, object>();
            dict1["id"] = 1;
            dict1["name"] = "dal makhni";
            dict1["price"] = 180;
            dict1["tag"] = "veg";

            dict1["description"] = "spicy daal from indian culture.";
            dict1["extra"] = "People Usualy like it";



            IDictionary<string, object> dict2 = new Dictionary<string, object>();
            dict2["id"] = 2;
            dict2["name"] = "stuffed naan";
            dict2["price"] = 110;
            dict2["tag"] = "veg";

            dict2["description"] = "Indian Style bread filled with mixed of vegetanle and potato.";
            dict2["extra"] = "People choice";

           


            return new object[] { dict1, dict2};
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
