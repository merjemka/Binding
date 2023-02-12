using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace MVVMExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
        // we notify binding clients that a property value changed
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

        }
            //propfull tab tab
        private string boundText;

        // we implement the interface of INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public string BoundText
        {
            get { return boundText; }
            set
            {
                boundText = value;
                //OnPropertyChanged();
                //invoking PropertyChanged
                // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BoundText"));
                OnPropertyChanged();
                    //Invoker takes(sender: this(coming from here, and boundtext)
                    //anytime the setter is set invoke the event that this propery has changed
                    // so that GUI can respond appropriately
            }
        }

        //setting click on button
        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            BoundText = "Set from code";
        }
        // to avoid multiple invoking we make a method
        private void OnPropertyChanged ([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
}

 }

