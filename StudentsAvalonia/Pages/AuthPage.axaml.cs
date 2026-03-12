using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudentsAvalonia.Classes;
using StudentsAvalonia.Data;
using System.Linq;

namespace StudentsAvalonia;

public partial class AuthPage : Window
{
    public AuthPage()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var login = TxtLogin.Text;
        var password = TxtPassword.Text;

        var user = ConnectionClass.connect.Logins.Where(d => d.LoginName == login && d.Password == password).FirstOrDefault();
        if (user != null)
        {
            var home = new HomePage();
            home.Show();
            Close();
        }
        else
        {
            //НА ДОМ
        }
    }

    private void TextBlock_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        var reg = new RegistPage(new User(), new Login());
        reg.Show();
        Close();
    }

    

    
}