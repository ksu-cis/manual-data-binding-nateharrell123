using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ManualDataBinding.Data;

namespace ManualDataBinding.UI
{
    /// <summary>
    /// Interaction logic for NoteEditor.xaml
    /// </summary>
    public partial class NoteEditor : UserControl
    {
        private Note note;
        /// <summary>
        /// This is the note that will be edited by this control.
        /// </summary>
        public Note Note
        {
            get { return note; }
            set
            {
                if (note != null) note.NoteChangedEvent -= OnNoteChanged; // if old note exists, remove event listener.
                note = value;
                if(note != null)
                {
                    note.NoteChangedEvent += OnNoteChanged; // if changed, do event lisetener.
                    OnNoteChanged(note, new EventArgs());
                }
            }
        }
        public NoteEditor()
        {
            InitializeComponent();
        }

        public void OnNoteChanged(object sender, EventArgs e) // event listener.
        {
            if (Note == null) return;
            Title.Text = Note.Title;
            Body.Text = Note.Body;
        }

        public void OnTitleChanged(object sender, TextChangedEventArgs e)
        {
            Note.Title = Title.Text; // Title comes from .xaml
        }

        public void OnBodyChanged(object sender, TextChangedEventArgs e)
        {
            Note.Body = Body.Text; // Body comes from .xaml
        }
    }
}
