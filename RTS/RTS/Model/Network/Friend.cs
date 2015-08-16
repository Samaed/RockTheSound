using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Model.Network
{
    // Un ami contient un id et un nom
    public class Friend
    {
        private int _id;
        private string _name;

        public Friend(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
