using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WpfAppFun.DataAccess;
using WpfAppFun.Models;

namespace WpfAppFun.ViewModels;

public class GamesViewModel : ViewModelBase
{
	private readonly IGameDataProvider _gameDataProvider;

	public GamesViewModel(IGameDataProvider gameDataProvider)
	{
		_gameDataProvider = gameDataProvider;
	}

	public ObservableCollection<Game> Games { get; } = new();

	public override async Task LoadAsync()
	{
		if (Games.Any()) return;
		var games = await _gameDataProvider.GetAllAsync();

		if (games is null) return;
		foreach (var game in games)
		{
			Games.Add(game);
		}
	}

}
