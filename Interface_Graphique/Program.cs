using System;
using Gtk;

namespace Interface_Graphique
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            /*MainWindow win = new MainWindow();
            win.Show();*/
            //Create the Window
            Window myWin = new Window("My first GTK# Application! ");
            myWin.Resize(200, 200);

            //Create a label and put some text in it.
            Label myLabel = new Label();
            myLabel.Text = "Hello World!!!!";

            //Add the label to the form
            myWin.Add(myLabel);

            //Show Everything
            myWin.ShowAll();
            Application.Run();
        }
    }
}
