using WpfAppFun.Models;

namespace WpfAppFun.ViewModels;

public class FriendViewModel : ViewModelBase
{
	private readonly Friend _model;

	public FriendViewModel(Friend model)
	{
		_model = model;
	}

	public int ID => _model.ID;

	public string? Name
	{
		get => _model.Name;
		set
		{
			_model.Name = value;
			RaisePropertyChanged();
		}
	}

	public string? Emoji
	{
		get => _model.Emoji;
		set
		{
			_model.Emoji = value;
			RaisePropertyChanged();
		}
	}


}
