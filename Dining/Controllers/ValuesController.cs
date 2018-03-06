using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Dining.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            string outputMessage = null;
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<IDictionary<string,string>> itemList = new List<IDictionary<string, string>>();
            IDictionary<string, string> items = new Dictionary<string, string>();

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
                while(reader.Read()){

                    items["id"] = ((int)reader.GetValue(0)).ToString();
                    items["name"] = (string)reader.GetValue(1);
                    items["unit"] = (string)reader.GetValue(5);
                    items["category"] = (string)reader.GetValue(10);
                    items["price"] = "100";
                    itemList.Add(items);
                    items.Clear();




                        
                                
                }

                outputMessage = "Connection Open";
                cnn.Close();
            }
            catch (Exception ex)
            {
                outputMessage = "Cannot Connect to server" + ex;
            }

            return outputMessage;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
