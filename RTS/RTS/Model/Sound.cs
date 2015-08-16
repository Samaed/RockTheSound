using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RTS.Model
{
    public class Sound
    {
        // Chaque son a un id
        private string _id;
        // Chaque son a un nom
        private string _name;
        // Chaque son a un chemin vers le fichier qui le compose
        private string _uri;
        // Chaque son a un tableau d'octets qui sont les données du fichier son
        private byte[] _bytes;
        // Un son démarre ou non automatiquement et est ou non bouclé
        private bool _autoloop;
        private bool _autoplay;
        // Un son a une taille de fichier (utile pour la synchronisation)
        private long _fileSize = 0;

        // Constructeur à 6 arguments
        // Par défaut on ne boucle pas et on lit automatiquement
        public Sound(string id, string name, string uri, byte[] bytes, bool autoplay = true, bool autoloop = false)
        {
            this._id = id;
            this._name = name;
            this._uri = uri;
            this._bytes = bytes;
            this._autoplay = autoplay;
            this._autoloop = autoloop;
        }

        // On peut récupérer la taille du fichier. Si elle est nulle, on la recalcule.
        public long FileSize
        {
            get { if (_fileSize == 0) { _fileSize = this.GetFileSize(); } return _fileSize; }
        }

        // On peut affecter le chemin de fichier que l'on souhaite
        public string File
        {
            get { return _uri; }
            set { this._uri = value; }
        }

        // On peut affecter le nom que l'on souhaite au son
        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }

        // On peut récupérer son id
        public string ID
        {
            get { return _id; }
        }

        // On peut récupérer les octets qui composent le fichier
        public byte[] Bytes
        {
            get { return _bytes; }
        }

        // On peut affecter le fait que le son boucle automatiquement ou non
        public bool AutoLoop
        {
            get { return _autoloop; }
            set { this._autoloop = value; }
        }

        // On peut affecter le fait que le son démarre automatiquement ou non
        public bool AutoPlay
        {
            get { return _autoplay; }
            set { this._autoplay = value; }
        }

        // On lit via FileInfo la taille du fichier au chemin indiqué et on retourne la valeur
        private long GetFileSize()
        {
            FileInfo infos = new FileInfo(_uri);
            return infos.Length;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
