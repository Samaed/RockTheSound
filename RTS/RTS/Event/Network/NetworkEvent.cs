using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Network
{
    public class NetworkEvent : Event
    {
        public enum NetworkAction
        {
            CONNECT,
            DISCONNECT,
            WELCOME,
            GOODBYE,
            SENDING_FILE,
            FILE_SENT,
            RECEIVING_FILE,
            FILE_RECEIVED,
            ERROR_FILE_SIZE,
            NO_SERVER_FOUND
        }

        private NetworkAction _action;

        public NetworkEvent(object source, NetworkAction action)
            : base(source, NetworkEvent.stringify(source, action))
        {
            this._action = action;
        }

        public NetworkAction Action
        {
            get { return _action; }
            set { _action = value; }
        }

        private static string stringify(object source, NetworkAction action)
        {
            return action.ToString() + " " + source.ToString();
        }
    }
}
