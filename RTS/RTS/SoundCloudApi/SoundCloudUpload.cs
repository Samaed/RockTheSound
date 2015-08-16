using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Krystalware.UploadHelper;

namespace RTS
{
    public class SoundCloudUpload
    {

        private WebClient client = new WebClient();
        //RTS Client id form SoundCloud
        private string _clientId = "9f046f2f160375c03245bc0cff353ca2"; 

        //RTS Client secret id from SoundCloud
        private string _clientSecret = "3388b3e58106ccc9422b3afb1309a346"; 

        //Credentials (username & password)
        private string _username = "";
        private string _password = "";

        //SoundCloud tracks end point
        private string _soundCloudTracksRes = "https://api.soundcloud.com/tracks";

        private string GetToken(){
            //Authentication data
            string postData = "client_id=" + _clientId
                + "&client_secret=" + _clientSecret
                + "&grant_type=password&username=" + _username
                + "&password=" + _password;
            string soundCloudTokenRes = "https://api.soundcloud.com/oauth2/token";

            string token = "";
            try
            {
                string tokenInfo = client.UploadString(soundCloudTokenRes, postData);
                // Parse the token
            tokenInfo = tokenInfo.Remove(0, tokenInfo.IndexOf("token\":\"") + 8);
            token = tokenInfo.Remove(tokenInfo.IndexOf("\""));
            }
            catch
            {
            }
            
            return token;
        }
        //Send the sound of filepath to SoundCloud on the account described by the username & the password
        public void SoundCloudUploadFile(string username, string password, string filePath, string title, string fileName)
        {
            _username = username;
            _password = password;
            string token = this.GetToken();
            if (token != "")
            {
                try
                {
                    //On prépare la requète avec différents paramètres
                    var request = WebRequest.Create(_soundCloudTracksRes) as HttpWebRequest;
                    request.Accept = "*/*";
                    request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
                    request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                    request.Headers.Add("Accept-Language", "en-US,en;q=0.8,ru;q=0.6");

                    //On envoit la requète sur le end point tracks avec les params requis par l'API
                    var files = new UploadFile[]{
                    new UploadFile(filePath, "track[asset_data]", "application/octet-stream")
                };
                    
                    var form = new NameValueCollection();
                    form.Add("track[title]", title);
                    form.Add("oauth_token", token);
                    form.Add("format", "json");

                    form.Add("Filename", fileName);
                    form.Add("Upload", "Submit Query");


                    try
                    {
                        using (var response = HttpUploadHelper.Upload(request, files, form))
                        {
                            using (var reader = new StreamReader(response.GetResponseStream()))
                            {

                            }
                        }
                    }
                    catch
                    {

                    }
                }catch{
                }
            }
        }

    }
}
