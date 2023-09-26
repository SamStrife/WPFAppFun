using System.Collections.Generic;
using System.Threading.Tasks;
using WpfAppFun.Models;

namespace WpfAppFun.DataAccess;


public interface IGameDataProvider
{
	Task<IEnumerable<Game>?> GetAllAsync();
}

public class GameDataProvider : IGameDataProvider
{
	public async Task<IEnumerable<Game>?> GetAllAsync()
	{
		await Task.Delay(100);

		return new List<Game>
		{
			new Game{Id = 1, Name = "Baldur's Gate 3"},
			new Game{Id = 2, Name = "Fallout: New Vegas"},
		};
	}
}
