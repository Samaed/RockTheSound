using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTS.Tools;
using System.Windows.Forms;
using RTS.Model;

namespace RTS.Controller
{
    // Le gestionnaire de raccourci est une classe générique qui accepte des clés de tout type
    public class ShortcutManager<T>
    {
        // On définit une instance statique de ShortcutManager<T> (pattern singleton)
        private static ShortcutManager<T> INSTANCE;

        // On utilise un dictionnaire bijectif de clés vers sons
        private BiDictionary<T, Sound> _dictionary;

        // On fournit une fonction statique afin de récupérer l'instance. Si elle n'existe pas on la crée. Elle sera donc unique
        public static ShortcutManager<T> GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ShortcutManager<T>();
            }
            return INSTANCE;
        }

        // On fournit une fonction statique afin de récupérer l'instance. Si elle n'existe pas on la crée. Elle sera donc unique
        public static ShortcutManager<T> GetInstance(IEqualityComparer<T> comparer)
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ShortcutManager<T>(comparer);
            }
            return INSTANCE;
        }

        // Constructeur sans arguments
        private ShortcutManager()
        {
            // On initialise notre dictionnaire bijectif comme vide
            this._dictionary = new BiDictionary<T, Sound>();
        }

        // Constructeur à 1 argument
        private ShortcutManager(IEqualityComparer<T> comparer)
        {
            // On initialise notre dictionnaire bijectif comme utilisant le comparateur d'égalité qu'on a passé en argument
            this._dictionary = new BiDictionary<T, Sound>(comparer);
        }

        // On récupère les dictionnaire bijectif
        public BiDictionary<T, Sound> Values
        {
            get { return _dictionary; }
        }

        // On associe le raccourci au son indiqué
        public void SetShortcut(Sound s, T k)
        {
            // Si son comme raccourcis ne sont pas nuls
            if (s != null && k != null)
            {
                // Si le son est bien dans le dictionnaire, on efface son entrée
                if (this._dictionary.ContainsValue(s))
                {
                    this._dictionary.TryRemoveBySecond(s);
                }
                // Si le raccourci est déjà dans le dictionnaire, on efface son entrée également
                if (this._dictionary.ContainsKey(k))
                {
                    this._dictionary.TryRemoveByFirst(k);
                }
                // On ajoute la nouvelle entrée et on sauvegarde la librairie de sons dans l'XML
                this._dictionary.Add(k, s);
                Tools.FileAccessor.SaveLibrary();
            }
        }

        // On récupère le raccourci du son indiqué
        public T GetShortcut(Sound s)
        {
            // Soit le raccourci existe auquel cas on le retourne soit on retourne la valeur par défaut du type de clé
            T k;
            try
            {
                k = this._dictionary.GetBySecond(s);
            }
            catch (ArgumentException)
            {
                k = default(T);
            }
            return k;
        }

        // On récupère le son associé au raccourci indiqué
        public Sound GetSound(T k)
        {
            // Si le raccourci est non nul, on retourne le son associé
            Sound s = null;
            if (k != null)
                this._dictionary.TryGetByFirst(k, out s);
            return s;
        }
    }
}
