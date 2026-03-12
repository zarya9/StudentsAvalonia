using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudentsAvalonia.Classes;
using StudentsAvalonia.Data;
using System;
using System.Linq;

namespace StudentsAvalonia;

public partial class RegistPage : Window
{
    //указываем непосредственно таблицу из бд
    Data.User user;
    Data.Login login;

    //указываем на элементы в приложении
    public RegistPage(Data.User _user, Data.Login _login)
    {
        InitializeComponent();
        user = _user;
        login = _login;
        this.DataContext = user;
        CmbxGroup.ItemsSource = ConnectionClass.connect.Groups.ToList();
    }

    private void BtnAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //1. Сохранение в таблицу логин и пароль
        login.LoginName = TxtLogin.Text;
        login.Password = TxtPassword.Text;
        ConnectionClass.connect.Logins.Add(login);
        ConnectionClass.connect.SaveChanges();

        //2. Сохранение пользователя
        user.Fname = TxtSurname.Text;
        user.Name = TxtName.Text;
        user.Patronumic = TxtPatronumic.Text;
        user.DateBirth = DateOnly.FromDateTime(DpBirthday.SelectedDate.Value.DateTime);
        user.IdGroup = ((Group)CmbxGroup.SelectedItem).IdGroup;

        //внешний ключ берется из новой записи логинов
        user.IdLogPass = login.IdLogins;
        ConnectionClass.connect.Users.Add(user);
        ConnectionClass.connect.SaveChanges();
        var window = new AuthPage();
        window.Show();
        Close();
    }

    private void BtnAddImage_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        
    }



    private void CmbxGroup_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var g = CmbxGroup.SelectedItem as Group;
        if (g != null)
        {
            TxtSpec.Text = ConnectionClass.connect.Specialities.Where(z => z.IdSpeciality == g.IdSpeciality).FirstOrDefault().NameSpeciality;
        }
    }

    private void BtnBack_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var window = new AuthPage();
        window.Show();
        Close();
    }
}