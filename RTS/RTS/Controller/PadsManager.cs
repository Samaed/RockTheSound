using RTS.Model;
using RTS.View.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RTS.Controller
{
    // On utilisera un PadsManager pour le fichier XML de configuration des 12 Pads
    public class PadsManager
    {
        // On définit une instance statique de PadsManager (pattern singleton)
        private static PadsManager INSTANCE;

        // On aura besoin d'une liste de PadView
        private List<PadView> _pads;
        // On définit des constantes de nommage
        private const string PAD = "Pad";
        private const string PADS = "Pads";
        private const string SOUND_ID = "soundId";

        // On fournit une fonction statique afin de récupérer l'instance. Si elle n'existe pas on la crée. Elle sera donc unique
        public static PadsManager GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new PadsManager();
            }
            return INSTANCE;
        }

        // Constructeur sans arguments
        private PadsManager()
	    {
            // On initialise la liste des PadView
            _pads = new List<PadView>();
	    }

        // On sérialise en XElement les sons associés aux pads
        private XElement ToXML()
        {
            // On initialise un tableau de XElement de la taille du nombre de pads
            XElement[] XPads = new XElement[_pads.Count];
            int i = 0;

            // Pour chaque pad
            foreach (PadView pad in _pads)
            {
                // On l'ajoute dans le tableau en y associant l'id du son qu'il contient (champ Data)
                XPads[i++] = new XElement(PAD, new XElement(SOUND_ID, (string)pad.Data));
            }

            // On retourne le XElement créé ainsi
            return new XElement(PADS, XPads);
        }

        // On sauvegarde le manager dans le fichier indiqué dans la configuration de l'application
        public void Save() {
            string XMLPadsBind = ConfigurationManager.AppSettings["XMLPadsBind"];
            // On récupère le XElement équivalent que l'on transforme en XDocument puis qu'on enregistre dans le fichier
            XDocument xdoc = new XDocument(this.ToXML());
            xdoc.Save(XMLPadsBind);
        }

        // On charge dans la liste de pads les données du fichier
        public static void Load(List<PadView> pads)
        {
            string XMLPadsBind = ConfigurationManager.AppSettings["XMLPadsBind"];
            // Si le fichier de configuration existe
            if (File.Exists(XMLPadsBind))
            {
                // On charge en XDocument le fichier et on détermine sa racine
                XDocument xdoc = XDocument.Load(XMLPadsBind);
                XElement root = xdoc.Root;

                // On récupère toutes les balises filles de <Pad></Pad>
                IEnumerable<XElement> list = root.Descendants(PAD);
                int i = 0;
                int nbPads = pads.Count;
                // Pour chacune de ces balises
                foreach (XElement item in list)
                {
                    // On récupère l'id du son
                    string soundId = item.Element(SOUND_ID).Value;
                    if (i < nbPads)
                    {
                        // On met à jour le champ Data
                        pads[i].Data = (object)soundId;
                    }
                    i++;
                }
            }
            PadsManager.GetInstance()._pads = pads;
        }

    }
}
