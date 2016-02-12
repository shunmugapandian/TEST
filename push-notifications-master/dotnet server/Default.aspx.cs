using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string regIds = "dMZ0YINIGBI:APA91bFb3AlbyL9PYbR_gJglvBQ6L0byG7CYGjHChQGtKBjSDnMk_q-H057EGE1nTnk5JIukhbvMxdGjIK-yTDiEQfm9bO2GOBE6VS7Ffdb6w2rFLeUQT43B5DVUhgYm7psxH5aHvEGJ";

                string AppId = "AIzaSyDcjptRCuqZ4LdIrWsFn2FCr6AAYRblkKc";
                string postString = string.Format("registration_id={0}&data.message=hello world", regIds);
                
                System.Net.ServicePointManager.Expect100Continue = false;

                
                HttpWebRequest webRequest = WebRequest.Create("https://android.googleapis.com/gcm/send") as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Headers.Add(string.Format("Authorization: key={0}", AppId));
                webRequest.ContentLength = postString.Length;
                

                Byte[] byteArray =  System.Text.Encoding.UTF8.GetBytes(postString);
                webRequest.ContentLength = byteArray.Length;
            
                Stream dataStream = webRequest.GetRequestStream();

                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = webRequest.GetResponse();
                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();   //Get response from GCM server.

                 Response.Write( sResponseFromServer);      //Assigning GCM response to Label text 

                tReader.Close();

                dataStream.Close();
                tResponse.Close();         


                //StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                //requestWriter.Write(postString);
                //requestWriter.Close();

                //StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                //string responseData = responseReader.ReadToEnd();

                //responseReader.Close();
                //webRequest.GetResponse().Close();

                //Response.Write( responseData);

        }
    }
}
