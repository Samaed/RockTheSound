using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IrrKlang;
using System.Reflection;

namespace RTS.Model
{
    // Un sound altéré est un son sur lequel on applique des effets
    public class AffectedSound : Sound
    {
        // On va stocker un dictionnaire de booleans pour déterminer si les effets sont actifs ou non
        private Dictionary<string, Boolean> _effects;

        // Constructeur à 6 arguments
        public AffectedSound(string id, string name, string uri, byte[] bytes, bool autoplay = true, bool autoloop = false)
            : base(id, name, uri, bytes, autoplay, autoloop)
        {
            // On ajoute tous les effets comme étant désactivés
            this._effects = new Dictionary<string, bool>();
            this._effects.Add("Echo", false);
            this._effects.Add("Distortion", false);
            this._effects.Add("Chorus", false);
            this._effects.Add("Compressor", false);
            this._effects.Add("Flanger", false);
            this._effects.Add("I3DL2Reverb", false);
        }

        // On peut récupérer les effets et leur état
        public Dictionary<string, Boolean> Effect
        {
            get { return _effects; }
        }
    }
}
