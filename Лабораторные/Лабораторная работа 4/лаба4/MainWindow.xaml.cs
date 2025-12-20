using System.Windows;
using System.Windows.Media;

namespace WpfLab7
{
    public partial class MainWindow : Window
    {
        RotateTransform rot = new RotateTransform(0);

        public MainWindow()
        {
            InitializeComponent();

            MyPoly.RenderTransform = rot;
            MyPoly.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void Rotate_Click(object sender, RoutedEventArgs e)
        {
            rot.Angle += 15;
        }
    }
}
