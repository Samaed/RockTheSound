using RTS.Observer;
using RTS.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RTS.Tools;
using RTS.Event.Playback;
using RTS.Event.Metronome;
using RTS.Event.Network;
using RTS.Event.Library;
using RTS.Event.Record;
using RTS.Event.Export;

namespace RTS.View.Controls
{


    public class ConsoleView : RichTextBox, Observer<Event.Event>, Observer<NetworkEvent>, Observer<MetronomeEvent>, Observer<ErrorEvent>, Observer<SequenceEvent>
    {
        delegate void SetTextCallback(string text);

        private TimeLimiter<String> _limiter = new TimeLimiter<String>(500);

        public ConsoleView()
        {
            this.AutoScroll();
        }

        public void WriteLine(String s)
        {
            if (s != String.Empty && s != default(String))
            {
                try
                {
                    SetTextCallback d = new SetTextCallback(SafeWriteLine);
                    this.Invoke(d, new object[] { s });
                }
                catch (Exception)
                {
                    // Catch an exception thrown when parent form is closing
                }
            }
        }

        public void SafeWriteLine(String s)
        {
            this.Text += ">> " + s + "\n";
            this.AutoScroll();
        }

        public void AutoScroll()
        {
            if (this.TextLength > 0)
            {
                this.SelectionStart = this.TextLength - 1;
                this.ScrollToCaret();
            }
        }

        public void Refresh(Event.Event e)
        {
            if (e is ErrorEvent || e is ExportEvent)
            {
                this.WriteLine(e.ToString());
            }
            else if (e is VolumeEvent || e is MetronomeEvent)
            {
                string s = _limiter.push(e.ToString());
                this.WriteLine(s);
            }
        }

        public void Refresh(NetworkEvent e)
        {
            this.WriteLine(e.ToString());
        }

        public void Refresh(MetronomeEvent e)
        {
            if (e is SpeedEvent)
            {
                string s = _limiter.push(e.ToString());
                this.WriteLine(s);
            }
        }

        public void Refresh(ErrorEvent e)
        {
            this.WriteLine(e.ToString());
        }

        public void Refresh(SequenceEvent e)
        {
            if (!(e is UpdateEvent))
                this.WriteLine(e.ToString());
        }
    }
}
