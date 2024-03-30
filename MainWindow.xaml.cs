using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        int generatedCode;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MailAdress.Text) && !string.IsNullOrEmpty(Password.Text))
            {
                generatedCode = random.Next(1000, 9999);
                MailSend.SendMail(MailAdress.Text, "Код для регистрации", $"{generatedCode}");

                // Отображаем всплывающее окно для ввода кода
                var inputDialog = new InputDialog();
                inputDialog.Owner = this; // Устанавливаем главное окно как владельца
                bool? dialogResult = inputDialog.ShowDialog(); // Отображаем окно как диалоговое

                // Проверяем результат диалога
                if (dialogResult == true)
                {
                    int enteredCode;
                    if (int.TryParse(inputDialog.EnteredCode, out enteredCode))
                    {
                        if (enteredCode == generatedCode)
                        {
                            MessageBox.Show("Вы успешно вошли", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Неправильный код", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный формат кода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}