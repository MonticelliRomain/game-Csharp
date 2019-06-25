using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        Console.WriteLine(button3);
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    public void OnButton3Clicked(object sender, EventArgs e)
    {
        Window Game = new Window("");
        Game.Resize(200, 200); 

        //Create a label and put some text in it.
        Label myLabel = new Label();
        myLabel.Text = "El Carry Del Fueeegoooo";

        //Add the label to the form
        Game.Add(myLabel);

        //Show Everything
        Game.ShowAll();
    }
}
