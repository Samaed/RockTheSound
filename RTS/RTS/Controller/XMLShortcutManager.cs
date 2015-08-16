using NAudio.Midi;
using RTS.Controller.MIDI.NoteID;
using RTS.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RTS.Controller
{
    public class XMLShortcutManager
    {
        // On définit une instance statique de ShortcutManager<T> (pattern singleton)
        private static XMLShortcutManager INSTANCE;

        // On va devoir gérer le manageur de raccourci de Keys (clavier) et NoteID (MIDI)
        private ShortcutManager<Keys> _keyManager;
        private ShortcutManager<NoteID> _midiNoteManager;

        // On définit des variables de nommage
        private const string KEYCODE = "keycode";
        private const string KEY = "Key";
        private const string SOUND_ID = "soundId";
        private const string BINDS = "binds";
        private const string NOTE = "Note";
        private const string NOTE_ID = "noteId";

        // On fournit une fonction statique afin de récupérer l'instance. Si elle n'existe pas on la crée. Elle sera donc unique
        public static XMLShortcutManager GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new XMLShortcutManager();
            }
            return INSTANCE;
        }

        // Constructeur sans arguments
        private XMLShortcutManager()
        {
        }

        // On retourne un XElement équivalent à la configuration actuelle
        private XElement ToXML()
        {
            // On initialise un tableau de XElement de la taille du nombre de raccourcis Keys
            XElement[] XKeys = new XElement[_keyManager.Values.Count];
            int i = 0;
            
            // Pour chaque Keys dans le manageur, on crée un XElement avec le raccourci et le son associé
            foreach (Keys key in _keyManager.Values.GetFirsts())
            {
                XKeys[i++] = new XElement(KEY, new XElement(KEYCODE, key), new XElement(SOUND_ID, _keyManager.Values.GetByFirst(key).ID));
            }

            // On initialise un tableau de XElement de la taille du nombre de raccourcis NoteID
            XElement[] XPitch = new XElement[_midiNoteManager.Values.Count];
            i=0;

            // Pour chaque NoteID dans le manageur, on crée un XElement avec le raccourci et le son associé
            foreach (NoteID note in _midiNoteManager.Values.GetFirsts())
            {
                XPitch[i++] = new XElement(NOTE, new XElement(NOTE_ID, note.ID), new XElement(SOUND_ID, _midiNoteManager.Values.GetByFirst(note).ID));
            }

            // On retourne le XElement créé ainsi
            return new XElement(BINDS, XKeys, XPitch);
        }

        // On sauvegarde le manager dans le fichier indiqué dans la configuration de l'application
        public void Save()
        {
            string XMLKeysBind = ConfigurationManager.AppSettings["XMLKeysBind"];
            // On récupère le XElement équivalent que l'on transforme en XDocument puis qu'on enregistre dans le fichier
            XDocument xdoc = new XDocument(this.ToXML());
            xdoc.Save(XMLKeysBind);
        }

        // On charge dans les deux manageurs les données du document XML
        public static void Load(ShortcutManager<Keys> keyManager, ShortcutManager<NoteID> midiNoteManager)
        {
            string XMLKeysBind = ConfigurationManager.AppSettings["XMLKeysBind"];
            // Si le document XML existe
            if (File.Exists(XMLKeysBind))
            {
                // On charge le XDocument contenu dans le document XML
                XDocument xdoc = XDocument.Load(XMLKeysBind);
                // On récupère la racine du document
                XElement root = xdoc.Root;

                // On récupère la liste des balises fillse de <Key></Key>
                IEnumerable<XElement> keysList = root.Descendants(KEY);
                // Pour chacune de ces balises
                foreach (XElement item in keysList)
                {
                    // On ajoute le raccourci trouvé au manageur
                    string soundId = item.Element(SOUND_ID).Value;
                    string keyId = item.Element(KEYCODE).Value;
                    keyManager.SetShortcut(Model.Model.GetInstance().SoundLibrary.GetSoundByID(soundId), (Keys)Enum.Parse(typeof(Keys), keyId));
                }

                // On récupère la liste des balises filles de <Note></Note>
                IEnumerable<XElement> pitchsList = root.Descendants(NOTE);
                // Pour chacune de ces balises
                foreach (XElement item in pitchsList)
                {
                    // On ajoute le raccourci trouvé au manageur
                    string soundId = item.Element(SOUND_ID).Value;
                    string note = item.Element(NOTE_ID).Value;
                    midiNoteManager.SetShortcut(Model.Model.GetInstance().SoundLibrary.GetSoundByID(soundId), new NoteID(int.Parse(note)));
                }
            }
            XMLShortcutManager.GetInstance()._keyManager = keyManager;
            XMLShortcutManager.GetInstance()._midiNoteManager = midiNoteManager;
        }
    }
}
