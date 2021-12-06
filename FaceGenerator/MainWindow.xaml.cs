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
            cmbEyesColors.ItemsSource = typeof(Colors).GetProperties();
            cmbHatColors.ItemsSource = typeof(Colors).GetProperties();
            cmbNoseColors.ItemsSource = typeof(Colors).GetProperties();
            cmbMouthColors.ItemsSource = typeof(Colors).GetProperties();
        }

        private void randomFaceBtn_Click(object sender, RoutedEventArgs e)
        {
            Random randomItem = new Random();
            int faceAmount = cmbFaceColors.Items.Count;
            int eyesAmount = cmbEyesColors.Items.Count;
            int hatAmount = cmbHatColors.Items.Count;
            int noseAmount = cmbNoseColors.Items.Count;
            int mouthAmount = cmbMouthColors.Items.Count;                      
            cmbFaceColors.SelectedIndex = randomItem.Next(0, faceAmount + 1);
            cmbEyesColors.SelectedIndex = randomItem.Next(0, eyesAmount + 1);
            cmbHatColors.SelectedIndex = randomItem.Next(0, hatAmount + 1);
            cmbNoseColors.SelectedIndex = randomItem.Next(0, noseAmount + 1);
            cmbMouthColors.SelectedIndex = randomItem.Next(0, mouthAmount + 1);
        }

        private void cmbFaceColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbFaceColors.SelectedItem as PropertyInfo).GetValue(null, null);
            faceEllipse.Fill = new SolidColorBrush(selectedColor);
        }

        private void cmbEyesColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbEyesColors.SelectedItem as PropertyInfo).GetValue(null, null);
            eyeEllipse1.Fill = new SolidColorBrush(selectedColor);
            eyeEllipse2.Fill = new SolidColorBrush(selectedColor);
        }

        private void cmbHatColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbHatColors.SelectedItem as PropertyInfo).GetValue(null, null);
            hatPolygon.Fill = new SolidColorBrush(selectedColor);
        }

        private void cmbNoseColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbNoseColors.SelectedItem as PropertyInfo).GetValue(null, null);
            nosePolygon.Fill = new SolidColorBrush(selectedColor);
        }

        private void cmbMouthColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbMouthColors.SelectedItem as PropertyInfo).GetValue(null, null);
            mouthPolygon.Fill = new SolidColorBrush(selectedColor);
        }
    }
}
