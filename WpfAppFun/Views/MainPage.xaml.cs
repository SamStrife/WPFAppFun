using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppFun.Views;

public partial class MainPage : UserControl
{
    public MainPage()
    {
        InitializeComponent();
        
        var items = new List<FriendListName>
        {
            new() { Name = "Sam", Emoji = "😊" },
            new() { Name = "Erik", Emoji = "😁" },
            new() { Name = "Joe", Emoji = "😘" }
        };

        FriendsList.ItemsSource = items;
    }
    
    private void SwitchMainWindowButton_Click(object sender, RoutedEventArgs e)
    {
        switch (Grid.GetColumn(PinkPanel))
        {
            case 0:
                Grid.SetColumn(PinkPanel, 1);
                Grid.SetColumn(GreyPanel, 0);
                break;
            default:
                Grid.SetColumn(PinkPanel, 0);
                Grid.SetColumn(GreyPanel, 1);
                break;
        }
    }

    private void AddFriendButton_Click(object sender, RoutedEventArgs e)
    {
        FriendsList.Items.Add("Mitchel");
    }
}

public class FriendListName
{
    public string Name { get; set; } = "Default";
    public string Emoji { get; set; } = "⛔";
}