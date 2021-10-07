using CredentialManagement;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Card_Details.Controllers
{
    public class DocFileController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route("api/DocFile/CardDetails")]
        public HttpResponseMessage CardDetails()
        {
            var data = GetCredential("CardDetails_Credentials");//CardNumber //CardDetails_Credentials //CC_Details
            try
            {
                using (var client = new WebClient { UseDefaultCredentials = true })
                {
                    byte[] responseArray = Encoding.UTF8.GetBytes((data).ToString());
                    string response = Encoding.ASCII.GetString(responseArray);
                    return Request.CreateResponse(HttpStatusCode.Created, data);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
            finally
            {
                data.ToString();
            }
        }

        public UserPass GetCredential(string target)
        {
            var cm = new Credential { Target = target };
            if (!cm.Load())
            {
                return null;
            }
            // UserPass is just a class with two string properties for user and pass
            return new UserPass(cm.Username, cm.Password);
        }

        public class UserPass
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public UserPass(string user, string pass)
            {
                UserName = user;
                Password = pass;
            }
        }
    }
}
