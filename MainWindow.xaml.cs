using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MaszynaLosujaca _maszynaLosujaca;
        Model model;

        public MainWindow()
        {
            InitializeComponent();
            model = new Model();
            this.DataContext = model;
            _maszynaLosujaca = new MaszynaLosujaca();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Wiem że w tym miejscu lepiej by było zrobić 2 metody, ale zrobiłem tak, bo czemu nie.
            if (sender is Button button)
                switch (button.Name)
                {
                    case "Button_In":
                        _maszynaLosujaca.Add(model.TextBox_Text);
                        //MessageBox.Show(model.TextBox_Text);
                        model.TextBox_Text = "";
                        break;
                    case "Button_Out":
                        if (_maszynaLosujaca.AreThereAnyWords is false)
                            MessageBox.Show("Nie ma żadnych losów w maszynie!");
                        else
                            model.Label_Text = _maszynaLosujaca.GetRandomWord();
                        break;
                    default:
                        Console.Error.WriteLine("This event sender is not mapped!!");
                        break;
                }
            this.DataContext = null;
            this.DataContext = model;
        }
    }

    class Model
    {
        public string TextBox_Text { get; set; } = "Los";
        public string Label_Text { get; set; } = "...";

    }
}
