using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Http;

namespace VF.Cotg.WebServer.Controller
{

    /// <summary>
    /// A Test Controller
    /// </summary>
    public class TestController : ApiController
    {

        public IEnumerable<string> GetTest()
        {
            return new string[] { "One", "Two", "three" };
        }

    }
}
