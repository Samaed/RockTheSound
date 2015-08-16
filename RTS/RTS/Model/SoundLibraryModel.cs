using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTS.Model;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.IO;
using RTS.Controller;
using System.Windows.Forms;
using RTS.Event.Library;
using RTS.Observer;

namespace RTS.Model
{
    // La bibliothèque de son envoie des évènements LibraryEvent c'est donc un Observable
    public class SoundLibraryModel : Observable<LibraryEvent>
    {
        // On aura besoin d'un dictionnaire de sons selon leur id
        private Dictionary<string, Sound> _sounds;
        // La bibliothèque peut être ou non modifiée
        private bool _modified;

        // Constructeur sans arguments
        public SoundLibraryModel()
        {
            this._sounds = new Dictionary<string, Sound>();
        }

        // On peut indiquer que la bibliothèque est ou non modifiée
        public bool Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        // On peut récupérer le dictionnaire de sons
        public Dictionary<string, Sound> SoundsDictionary
        {
            get { return _sounds; }
        }

        // On peut récupérer uniquement une liste des sons dans la bibliothèque
        public List<Sound> Sounds
        {
            get { return new List<Sound>(this._sounds.Values); }
        }

        // On peut y ajouter un son
        public void AddSound(Sound s)
        {
            string ID = s.ID;
            
            // Si l'id existe déjà, on lève une exception
            if (this._sounds.ContainsKey(ID))
            {
                throw new Exception("Sound ID Conflict");
            }

            // Si le son n'existe pas on l'ajoute et on indique qu'on est modifié.
            // On notifie les observateurs de l'ajout d'un fichier et on retourne le son
            this._sounds.Add(ID, s);
            this.Modified = true;
            this.NotifyObservers(new LibraryEvent(this, LibraryEvent.LibraryAction.ADD, s));
        }

        // On peut ajouter un son par son chemin
        public void AddSound(String path)
        {
            // Le nom du son sera le nom du fichier sans extension
            string name = path.Substring(path.LastIndexOf("\\") + 1);
            name = name.Substring(0, name.LastIndexOf(".") );
            // On génère un ID à partir du chemin du son
            string id = SoundLibraryModel.GenerateID(path);
            // On ajoute enfin le son avec son id, son chemin et son nom
            this.AddSound(id, path, name);
        }

        // On peut ajouter un son par ses id, chemin et nom
        public void AddSound(string id, String path, String name)
        {
            AffectedSound s = new AffectedSound(id, name, path, RTS.Tools.FileAccessor.ReadFile(path));
            this.AddSound(s);
        }

        // On peut récupérer un son par son id
        public Sound GetSoundByID(string id)
        {
            Sound val;
            // On essaie de récupérer le son via son id, s'il n'existe pas on retourne null
            if (this._sounds.TryGetValue(id, out val))
            {
                return val;
            }
            return null;
        }

        // On peut supprimer un son par son id
        public void RemoveSound(string id)
        {
            // Si l'id est bien dans le dictionnaire
            if(this._sounds.ContainsKey(id)){
                // On retrouve le son et on le supprime
                Sound s = this._sounds[id];
                this._sounds.Remove(id);
                // On notifie les observateurs de la suppression
                this.NotifyObservers(new LibraryEvent(this, LibraryEvent.LibraryAction.REMOVE, s));
            }
        }

        // Retourne si un son est valide ou non (correspond à celui de la bibliothèque)
        public bool IsValidSound(Sound s)
        {
            return GenerateID(s.File).Equals(s.ID);
        }

        // On génère l'id du son à partir de son chemin
        public static string GenerateID(string path)
        {
            FileInfo infos = new FileInfo(path);
            long length = infos.Length;
            // Calcul de l'id en fonction de la taille du fichier(arrondie à 1000) et de son nom
            length = (length - length % 1000)/1000;
            // le tout hashé et replacé en string

            string name = path.Substring(path.LastIndexOf("\\") + 1);
            int lastOpenParenthesis = name.LastIndexOf("(");
            int lastCloseParenthesis = name.LastIndexOf(")");

            string cleanName;

            if (lastOpenParenthesis != -1 && lastCloseParenthesis != -1)
            {
                cleanName = name.Substring(0, lastOpenParenthesis) + name.Substring(lastCloseParenthesis + 1, name.Length - lastCloseParenthesis - 1);
            }
            else
            {
                cleanName = name;
            }

            return (cleanName+length).GetHashCode().ToString();
        }

        // On retourne la liste des samples de la bibliothèque sous forme de chaîne (délimiteur ";")
        public string GetStringSampleList()
        {
            string sampleList = string.Empty;
            foreach (Sound snd in this._sounds.Values)
            {
                sampleList += snd.ID + ";";
            }
            return sampleList;
        }

        // On retourne un XElement équivalent à la bibliothèque actuelle
        public XElement ToXML()
        {
            XElement x = new XElement("Sounds");
            Sound s;

            // On initialise un tableau de XElement de la taille du nombre de sons
            XElement[] Xsounds = new XElement[this.SoundsDictionary.Count];
            int i = 0;

            // Pour chaque paire dans le dictionnaire, on crée un XElement avec le son, son id et le chemin vers le fichier
            foreach (KeyValuePair<string, Sound> item in this.SoundsDictionary)
            {
                s = item.Value;
                Xsounds[i++] = new XElement("Sound", new XElement("name", s.Name), new XElement("id", s.ID), new XElement("path", s.File));
            }

            // On retourne le XElement créé ainsi
            return new XElement("Sounds", Xsounds);
        }
    }
}
