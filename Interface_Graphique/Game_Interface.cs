using System;
using Gtk; 


    public partial class GameInterface : Gtk.Window
    {
        public GameInterface(Window myWin) : base(Gtk.WindowType.Toplevel)
        {
            Label myLabel = new Label();
            myLabel.Text = "Hello World!!!!";
            myWin.Add(myLabel);
            myWin.ShowAll();
        }
        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }
    }

