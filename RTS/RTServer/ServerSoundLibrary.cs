using RTS.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace RTServer
{
    class ServerSoundLibrary
    {
        private static ServerSoundLibrary INSTANCE;
        public static ServerSoundLibrary GetInstance(){
            if (INSTANCE == null)
            {
                INSTANCE = new ServerSoundLibrary();
            }
            return INSTANCE;
        }
        private SoundLibraryModel _soundLibrary;
        
        private string _XMLFilePath;
        private ServerSoundLibrary()
        {
            _XMLFilePath = ConfigurationManager.AppSettings["severXMLLibraryName"];
            if (File.Exists(_XMLFilePath))
            {
                XDocument xdoc = XDocument.Load(_XMLFilePath);
                this._soundLibrary = RTS.Tools.FileAccessor.LoadLibrary(xdoc);
            }
            else
            {
                this._soundLibrary = new SoundLibraryModel();
            }
            this.Save();
        }
        public void Save()
        {
            XDocument xdoc = new XDocument();
            xdoc.Add(_soundLibrary.ToXML());
            xdoc.Save(_XMLFilePath);
        }
        public void AddSound(Sound s)
        {
            this._soundLibrary.AddSound(s);
            this.Save();
        }
        public Dictionary<string, Sound> GetSounds()
        {
            return _soundLibrary.SoundsDictionary;
        }
        public SoundLibraryModel Data
        {
            get { return _soundLibrary; }
        }
    }
}
