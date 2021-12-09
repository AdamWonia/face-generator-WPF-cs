using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            // Inserting colours into combo boxes
            cmbFaceColors.ItemsSource = typeof(Colors).GetProperties();
            cmbEyesColors.ItemsSource = typeof(Colors).GetProperties();
            cmbHatColors.ItemsSource = typeof(Colors).GetProperties();
            cmbNoseColors.ItemsSource = typeof(Colors).GetProperties();
            cmbMouthColors.ItemsSource = typeof(Colors).GetProperties();
        }
        /// <summary>
        /// Saves the canvas to an image file in the selected directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)faceCanvas.RenderSize.Width - 20,
            (int)faceCanvas.RenderSize.Height + 10, 70d, 65d, PixelFormats.Default);
            renderTargetBitmap.Render(faceCanvas);

            var croppedBitmap = new CroppedBitmap(renderTargetBitmap, new Int32Rect());

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(croppedBitmap));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream file = File.OpenWrite(saveFileDialog.FileName))
                {
                    pngEncoder.Save(file);
                }
            }
        }
        /// <summary>
        /// Creates a random face using the Random class. Sets a random colour in each ComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Changes the colour of the face shape when selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFaceColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbFaceColors.SelectedItem as PropertyInfo).GetValue(null, null);
            faceEllipse.Fill = new SolidColorBrush(selectedColor);
        }
        /// <summary>
        /// Changes the colour of the eyes when selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEyesColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbEyesColors.SelectedItem as PropertyInfo).GetValue(null, null);
            eyeEllipse1.Fill = new SolidColorBrush(selectedColor);
            eyeEllipse2.Fill = new SolidColorBrush(selectedColor);
        }
        /// <summary>
        /// Changes the colour of the hat shape when selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbHatColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbHatColors.SelectedItem as PropertyInfo).GetValue(null, null);
            hatPolygon.Fill = new SolidColorBrush(selectedColor);
        }
        /// <summary>
        /// Changes the colour of the nose shape when selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbNoseColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbNoseColors.SelectedItem as PropertyInfo).GetValue(null, null);
            nosePolygon.Fill = new SolidColorBrush(selectedColor);
        }
        /// <summary>
        /// Changes the colour of the mouth shape when selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMouthColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbMouthColors.SelectedItem as PropertyInfo).GetValue(null, null);
            mouthPolygon.Fill = new SolidColorBrush(selectedColor);
        }
    }
}
