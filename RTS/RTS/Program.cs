using NAudio.Midi;
using RTS.Controller;
using RTS.Controller.MIDI.NoteID;
using RTS.Model;
using RTS.View.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RTS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string XMLFilePath = ConfigurationManager.AppSettings["XMLSamplesList"];
            SoundLibraryModel library;
            if (File.Exists(XMLFilePath))
            {
                try
                {
                    XDocument xdoc = XDocument.Load(XMLFilePath);
                    library = Tools.FileAccessor.LoadLibrary(xdoc);
                }
                catch (XmlException)
                {
                    library = new SoundLibraryModel();
                }
            }
            else
            {
                library = new SoundLibraryModel();
            }
            Model.Model.GetInstance().SoundLibrary = library;
            Tools.FileAccessor.SaveLibrary();

            XMLShortcutManager.Load(ShortcutManager<Keys>.GetInstance(), ShortcutManager<NoteID>.GetInstance(NoteID.Comparer));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RTS.View.MainFrame mainFrame = new RTS.View.MainFrame();
            List<PadView> padList = new List<PadView>();
            foreach (Control ctrl in mainFrame.Controls)
            {
                if (ctrl is PadView)
                {
                    padList.Add((PadView)ctrl);
                }
            }
            PadsManager.Load(padList);
            Application.Run(mainFrame);
        }
    }
}
