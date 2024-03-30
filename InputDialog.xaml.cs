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
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для InputDialog.xaml
    /// </summary>
    public partial class InputDialog : Window
    {
        public InputDialog()
        {
            InitializeComponent();
        }
        public string EnteredCode { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnteredCode = CodeTextBox.Text;
            DialogResult = true; // Устанавливаем результат диалога как успешный
        }
    }
}
