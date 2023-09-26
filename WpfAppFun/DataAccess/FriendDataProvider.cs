using System.Collections.Generic;
using System.Threading.Tasks;
using WpfAppFun.Models;

namespace WpfAppFun.DataAccess;

public interface IFriendDataProvider
{
	Task<IEnumerable<Friend>?> GetAllAsync();
}


public class FriendDataProvider : IFriendDataProvider
{
	public async Task<IEnumerable<Friend>?> GetAllAsync()
	{
		await Task.Delay(100);

		return new List<Friend>
		{
			new Friend{ID = 1, Name="Erik", Emoji="😊"},
			new Friend{ID = 2, Name="Sam", Emoji="😂"},
			new Friend{ID = 3, Name="Joe", Emoji="😘"}
		};
	}
}
