//using Nancy.Json;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Notification
{
    public class fcmNotification
    {

        public void customerNotification(string deviceid, string message, string img, string title)
        {

            if (string.IsNullOrEmpty(deviceid))
            {

            }
            else
            {


                try
                {
                    string sResponseFromServer = string.Empty, finalResult = string.Empty;
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    //serverKey - Key from Firebase cloud messaging server   customer
                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                    //store
                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));

                    //tRequest.Headers.Add(string.Format("Sender: id={0}", "844325225983"));

                    tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAinTYmew:APA91bHzKggJRlOwM0Yg6O1Xq3b7Rqwf8E5d6XsWvzLszX2aoCy7XMiOE6i1WoiJHkNnzo2WOTxWpqJ6Z3S9WMmfx_n4A_Xz_HgTWkT0B1hxcVtFaFN9dYplDPJ_4Z1tklhDKwiq2v-k"));

                    tRequest.Headers.Add(string.Format("Sender: id={0}", "594665839084"));
                    tRequest.ContentType = "application/json";
                    var payload = new
                    {
                        to = deviceid,
                        priority = "high",
                        content_available = true,
                        notification = new
                        {
                            body = message,
                            title = title,
                            badge = 1
                        },
                        data = new
                        {

                            key1 = "value1",
                            key2 = "value2"
                        }

                    };

                    //string postbody = JsonConvert.SerializeObject(payload).ToString();

                    var serializer = new JavaScriptSerializer();
                    var postbody = serializer.Serialize(payload);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                    tRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        sResponseFromServer = tReader.ReadToEnd();
                                        //result.Response = sResponseFromServer;
                                    }
                            }
                        }
                    }

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
       
    }
}
