using RTS.Observer;
using RTS.Event.Playback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RTS.Controller.Network;
using RTS.Model;

namespace RTS.View.Controls
{
    public class PadView : TwoStateButton.TwoStateButton, Observer<Event.Event>
    {
        public void Refresh(Event.Event e)
        {
            if (e is PlaybackEvent)
            {
                if (((string)this.Data).Equals(((PlaybackEvent)e).Sound.ID))
                {
                    if (e is PlayEvent)
                    {
                        this.Active = true;
                    }
                    else if (e is EndEvent)
                    {
                        this.Active = false;
                    }
                }
            }
        }
    }
}
