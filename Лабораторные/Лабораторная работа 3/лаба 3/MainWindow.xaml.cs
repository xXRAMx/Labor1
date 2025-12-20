using System.Windows;
using System.Windows.Controls;
using System.Text;

namespace WpfLab6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Fill one list in XAML; here fill Combo programmatically
            ComboVerbs.Items.Add("бежит");
            ComboVerbs.Items.Add("идёт");
            ComboVerbs.Items.Add("летит");

            // Fill list in XAML? For demo: fill programmatically
            ListNouns.Items.Add("кот");
            ListNouns.Items.Add("собака");
        }

        private void Build_Click(object sender, RoutedEventArgs e)
        {
            if (ListNouns.SelectedItem == null || ComboVerbs.SelectedItem == null)
            {
                PhraseLabel.Content = "Выберите элементы.";
                return;
            }
            StringBuilder sb = new();
            sb.Append(ListNouns.SelectedItem.ToString()).Append(" ").Append(ComboVerbs.SelectedItem.ToString());
            PhraseLabel.Content = sb.ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EditBox.Text))
                ListNouns.Items.Add(EditBox.Text);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ListNouns.SelectedIndex >= 0)
                ListNouns.Items[ListNouns.SelectedIndex] = EditBox.Text;
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ListNouns.SelectedIndex >= 0)
                ListNouns.Items.RemoveAt(ListNouns.SelectedIndex);
        }

        private void EditBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // allow only letters
            foreach (char c in e.Text)
                if (!char.IsLetter(c))
                    e.Handled = true;
        }
    }
}
