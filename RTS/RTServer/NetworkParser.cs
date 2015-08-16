using RTS.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTServer
{
    public class NetworkParser
    {
        public enum Operation
        {
            JOIN, SERVER_PLAY, STOP, NEW_MEMBER, REMOVE_MEMBER, ASK_TO_PLAY, NONE, OK, DISCONNECT, HELLO, SAMPLE_LIST, GIVE_FILE, NEED_SAMPLES,
            ASK_FILE,
            READY,
            READY_TO_RECEIVE
        }
        private static BiDictionary<Operation, string> _dictionnary;
        public static Operation getOperation(string query)
        {
            if (_dictionnary == null)
            {
                NetworkParser.setValues();
            }
            Operation op = Operation.NONE;
            _dictionnary.TryGetBySecond(query,out op);
            return op;
        }

        private static void setValues()
        {
            _dictionnary = new BiDictionary<Operation, string>();
            _dictionnary.Add(Operation.ASK_TO_PLAY, "sp");
            _dictionnary.Add(Operation.JOIN, "j");
            _dictionnary.Add(Operation.SERVER_PLAY, "p");
            _dictionnary.Add(Operation.STOP, "s");
            _dictionnary.Add(Operation.NEW_MEMBER, "nm");
            _dictionnary.Add(Operation.REMOVE_MEMBER, "rm");
            _dictionnary.Add(Operation.OK, "ok");
            _dictionnary.Add(Operation.DISCONNECT, "disconnect");
            _dictionnary.Add(Operation.HELLO, "hello");
            _dictionnary.Add(Operation.SAMPLE_LIST, "sl");
            _dictionnary.Add(Operation.GIVE_FILE, "gf");
            _dictionnary.Add(Operation.NEED_SAMPLES, "ns");
            _dictionnary.Add(Operation.ASK_FILE, "af");
            _dictionnary.Add(Operation.READY, "ready");
            _dictionnary.Add(Operation.READY_TO_RECEIVE, "ready2receive");
            _dictionnary.Add(Operation.NONE, "");
        }

        public static string getCode(Operation operation)
        {
            if (_dictionnary == null)
            {
                NetworkParser.setValues();
            }
            string op = _dictionnary.GetByFirst(Operation.NONE);
            _dictionnary.TryGetByFirst(operation, out op);
            return op;
        }
    }
}
