using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace FaceGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbFaceColors.ItemsSource = typeof(Colors).GetProperties();
            cmbEyeColors.ItemsSource = typeof(Colors).GetProperties();
            cmbHatColors.ItemsSource = typeof(Colors).GetProperties();
            cmbNoseColors.ItemsSource = typeof(Colors).GetProperties();
            cmbMouthColors.ItemsSource = typeof(Colors).GetProperties();
        }

        private void colorBtn_Click(object sender, RoutedEventArgs e)
        {
            Color selectedColor = (Color)(cmbFaceColors.SelectedItem as PropertyInfo).GetValue(null, null);
            faceEllipse.Fill = new SolidColorBrush(selectedColor);
            eyeEllipse1.Fill = new SolidColorBrush(selectedColor);
            eyeEllipse2.Fill = new SolidColorBrush(selectedColor);
            hatPolygon.Fill = new SolidColorBrush(selectedColor);
        }
    }
}
