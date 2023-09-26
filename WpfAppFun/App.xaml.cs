using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfAppFun.DataAccess;
using WpfAppFun.ViewModels;

namespace WpfAppFun;

public partial class App : Application
{
	private readonly ServiceProvider _serviceProvider;

	public App()
	{
		ServiceCollection services = new();
		ConfigureServices(services);
		_serviceProvider = services.BuildServiceProvider();
	}

	private void ConfigureServices(ServiceCollection services)
	{
		services.AddTransient<MainWindow>();
		services.AddTransient<MainViewModel>();
		services.AddTransient<FriendListViewModel>();
		services.AddTransient<GamesViewModel>();
		services.AddTransient<IFriendDataProvider, FriendDataProvider>();
		services.AddTransient<IGameDataProvider, GameDataProvider>();
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);

		var mainWindow = _serviceProvider.GetService<MainWindow>();
		mainWindow?.Show();
	}
}