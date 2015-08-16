using NAudio.Midi;
using RTS.Controller;
using RTS.Controller.MIDI.NoteID;
using RTS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RTS
{
    public partial class ShortcutPopup : Form
    {
        delegate void SetTextCallback(string text);

        private Keys _key;
        private NoteID _note;
        private EventHandler<MidiInMessageEventArgs> _MIDIHandler;

        public ShortcutPopup()
        {
            InitializeComponent();
        }

        public Keys Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public NoteID Note
        {
            get { return _note; }
            set { _note = value; }
        }

        private void ShortcutPopup_Load(object sender, EventArgs e)
        {
            if (MIDIController.GetInstance().DevicesCount == 1)
            {
                this._MIDIHandler = new EventHandler<MidiInMessageEventArgs>(this.MIDIMessageReceived);
                MIDIController.GetInstance().AddMessageReceivedHandler(0, this._MIDIHandler);
            }

            this.KeyBox.Text = this.Key.ToString();

            if (this.Note != null && this.Note.ID > 0 && this.Note.ID <= 128)
            {
                NoteEvent n = new NoteEvent(0, 1, MidiCommandCode.NoteOn, this.Note.ID-1, 127);
                this.PitchBox.Text = n.NoteName;
            }
            else
            {
                this.PitchBox.Text = "None";
            }
        }

        private void ShortcutBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.Key = e.KeyCode;

            SetTextCallback d = new SetTextCallback(SetKeyBoxText);
            this.Invoke(d, new object[] { e.KeyCode.ToString() });
        }

        private void SetKeyBoxText(string text)
        {
            this.KeyBox.Text = text;
        }

        private void MIDIMessageReceived(object sender, MidiInMessageEventArgs e)
        {
            if (e.MidiEvent is NoteEvent)
            {
                this.Note = new NoteID(((NoteEvent)e.MidiEvent).NoteNumber+1);

                SetTextCallback d = new SetTextCallback(SetPitchBoxText);
                this.Invoke(d, new object[] { ((NoteEvent)e.MidiEvent).NoteName });
            }
        }

        private void SetPitchBoxText(string text)
        {
            this.PitchBox.Text = text;
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShortcutPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            MIDIController.GetInstance().RemoveMessageReceivedHandler(0, this._MIDIHandler);
        }
    }
}
