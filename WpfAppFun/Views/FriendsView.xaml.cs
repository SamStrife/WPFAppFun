using System.Windows;
using System.Windows.Controls;
using WpfAppFun.DataAccess;
using WpfAppFun.ViewModels;

namespace WpfAppFun.Views;

public partial class MainPage : UserControl
{
	private FriendListViewModel _viewModel;

	public MainPage()
	{
		InitializeComponent();
		_viewModel = new FriendListViewModel(new FriendDataProvider());
		DataContext = _viewModel;
		Loaded += FriendsView_Loaded;
	}

	private async void FriendsView_Loaded(object sender, RoutedEventArgs e)
	{
		await _viewModel.LoadAsync();
	}
}