using RTS.Controller;
using RTS.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RTS.Tools
{
    public class FileAccessor
    {
        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            try
            {
                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                int length = (int)fileStream.Length;
                buffer = new byte[length];
                int count;
                int sum = 0;

                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                {
                    sum += count;
                }

                fileStream.Close();
            }
            catch (Exception)
            {
                buffer = new byte[0];
            }
            return buffer;
        }

        public static bool WriteFile(string filePath, byte[] datas, int length)
        {
            try
            {
                FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                try
                {
                    fileStream.Write(datas, 0, length);
                }
                finally
                {
                    fileStream.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static SoundLibraryModel LoadLibrary(XDocument xdoc)
        {
            SoundLibraryModel slm = new SoundLibraryModel();
            XElement root = xdoc.Root;

            IEnumerable<XElement> list = root.Descendants("Sound");

            foreach (XElement item in list)
            {

                string id = item.Element("id").Value;
                string name = item.Element("name").Value;
                string path = item.Element("path").Value;
                if (File.Exists(path))
                {
                    slm.AddSound(id, path, name);
                }

            }
            return slm;
        }

        // Saves the library to the AppSettings["XMLSamplesList"]
        public static bool SaveLibrary()
        {
            try
            {
                XDocument xdoc = new XDocument();
                xdoc.Add(Model.Model.GetInstance().SoundLibrary.ToXML());
                xdoc.Save(ConfigurationManager.AppSettings["XMLSamplesList"]);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        // Saves the library to a given filename
        public static bool SaveLibrary(string filename)
        {
            try
            {
                XDocument xdoc = new XDocument();
                xdoc.Add(Model.Model.GetInstance().SoundLibrary.ToXML());
                xdoc.Save(filename);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool IsSoundFile(string filename)
        {
            string[] allowedFormat = new string[] { "mp3", "ogg", "wav", "mod", "it", "xm", "it", "s3d", "flac" };
            string[] split = filename.Split(new char[] { '.' });
            return allowedFormat.Contains<string>(split[split.Length - 1]);
        }
    }
}
