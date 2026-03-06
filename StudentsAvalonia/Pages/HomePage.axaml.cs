using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace StudentsAvalonia;

public partial class HomePage : Window
{
    public HomePage()
    {
        InitializeComponent();
        MainControl.Content = new StudentControl();
    }

    private void BtnStudents_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void BtnGroups_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void BtnSpeciality_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }
}