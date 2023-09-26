using System.Windows;
using WpfAppFun.DataAccess;
using WpfAppFun.ViewModels;

namespace WpfAppFun
{
	public partial class MainWindow : Window
	{
		private readonly MainViewModel _viewModel;

		public MainWindow()
		{
			InitializeComponent();
			_viewModel = new MainViewModel(
				new FriendListViewModel(new FriendDataProvider()),
				new GamesViewModel());
			DataContext = _viewModel;
			Loaded += MainWindow_Loaded;
		}

		private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			await _viewModel.LoadAsync();
		}
	}
}