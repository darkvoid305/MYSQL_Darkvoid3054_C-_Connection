using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataBaseConnectionTest.classes.Plugin
{
    class Web
    {

        public static string GetPost(string Url, params string[] postdata)
        {
            string result = string.Empty;
            string data = string.Empty;

            System.Text.ASCIIEncoding ascii = new ASCIIEncoding();

            if(postdata.Length % 2 != 0 )
            {

                MessageBox.Show("Parameters must be even ",Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

            for(int i = 0; i < postdata.Length; i+=2)
            {
                data += string.Format("&{0}={1}",postdata[i],postdata[i+1]);
            }

            data = data.Remove(0, 1);
            byte[] bytesarr = ascii.GetBytes(data);

            try
            {
                WebRequest request = WebRequest.Create(Url);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bytesarr.Length;

                System.IO.Stream streamwritter = request.GetRequestStream();
                streamwritter.Write(bytesarr,0,bytesarr.Length);
                streamwritter.Close();

                WebResponse response = request.GetResponse();
                streamwritter = response.GetResponseStream();

                System.IO.StreamReader streamread = new System.IO.StreamReader(streamwritter);
                result = streamread.ReadToEnd();
                streamread.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,Application.ProductName, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            return result;
        }


    }
}
