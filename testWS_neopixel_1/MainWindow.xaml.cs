using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Text.Json;
using System.Text.Json.Serialization;

namespace testWS_neopixel_1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Personne : INotifyPropertyChanged
        {
            private string _myText;
            private ObservableCollection<string> _myItems;

            public string MyText
            {
                get
                {
                    Trace.WriteLine("Get myText");
                    return _myText;
                }
                set
                {
                    Trace.WriteLine("Set myText");
                    _myText = value;
                    RaisePropertyChanged("MyText");
                }
            }
            public ObservableCollection<string> MyItems
            {
                get
                {
                    Trace.WriteLine("Get myItems");
                    return _myItems;
                }
                set
                {
                    Trace.WriteLine("Set myItems");
                    _myItems = value;
                    RaisePropertyChanged("MyItems");
                }
            }

            private void RaisePropertyChanged(String property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        private readonly Personne _myPersonne;

        public MainWindow()
        {
            var options = new JsonSerializerOptions
            {
                //                IncludeFields = true,
            };
            modelNeoPixel monModele = new modelNeoPixel();
            string jsonString = JsonSerializer.Serialize(monModele);

            Trace.WriteLine($"mise en chaine : {jsonString}");

            jsonString = @"{""Luminosite"":55,""Vitesse"":32,""Modes"":[""test 1"", ""test2""],""ModeActif"":0}";

            JsonDocument test = JsonDocument.Parse(jsonString);

            JsonElement root = test.RootElement;

            if(root.ValueKind == JsonValueKind.Object)
            {
                foreach(JsonProperty property in root.EnumerateObject())
                {
                    Trace.WriteLine($"clé : {property.Name} - valeur : {property.Value}");
                }
            }

            monModele = JsonSerializer.Deserialize<modelNeoPixel>(jsonString, options);

            jsonString = JsonSerializer.Serialize(monModele);

            Trace.WriteLine($"mise en chaine : {jsonString}");

            InitializeComponent();
            _myPersonne = new Personne { MyText = "Bobby", 
                                         MyItems = new ObservableCollection<string> 
                                            { "Peperonni Pizza", "Prout pizza" } };
            DataContext = _myPersonne;
        }

        private void ChangeListBox(object sender, RoutedEventArgs e)
        {
            _myPersonne.MyItems.Add(DateTime.Now.ToString());
        }

        private void ChangeTextBox(object sender, RoutedEventArgs e)
        {
            _myPersonne.MyText = _myPersonne.MyText + _myPersonne.MyText;
        }
    }
}
