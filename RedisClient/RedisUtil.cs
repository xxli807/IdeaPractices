using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Xml.Linq;

namespace RedisClient
{
    public class RedisUtil
    {
         

        public void CreateSampleString()
        {

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();


            db.StringSet("1", "testtesttest");

            //load xml
            var xDocument = XDocument.Load(@"C:\Work\HTR Technology and Service Pty Ltd\workspace\TelhealthCDAPackagingRest\EReferral_3A_Max.xml");
            var xmlString = xDocument.ToString();
            db.StringSet("2", xmlString);


            var value = db.StringGet("1");
            value = db.StringGet("2");
             
        }

       
    }
}
