using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace HypeTrainer.Import
{
    public class HtmlWebImport : HtmlWeb
    {
        public HtmlDocument SubmitFormValues(NameValueCollection fv, string url)
        {
            // Attach a temporary delegate to handle attaching
            // the post back data
            PreRequestHandler handler = delegate(HttpWebRequest request)
            {
                string payload = this.AssemblePostPayload(fv);
                byte[] buff = Encoding.ASCII.GetBytes(payload.ToCharArray());
                request.ContentLength = buff.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "*/*";
                System.IO.Stream reqStream = request.GetRequestStream();
                reqStream.Write(buff, 0, buff.Length);
                return true;
            };
            this.PreRequest += handler;
            HtmlDocument doc = this.Load(url, "POST");
            this.PreRequest -= handler;
            return doc;
        }

        private string AssemblePostPayload(NameValueCollection fv)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String key in fv.AllKeys)
            {
                sb.Append("&" + key + "=" + fv.Get(key));
            }
            return sb.ToString().Substring(1);
        }
    }
}
