using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WpfAppFun.Commands;
using WpfAppFun.DataAccess;
using WpfAppFun.Models;

namespace WpfAppFun.ViewModels;

public class FriendListViewModel : ViewModelBase
{
	private readonly IFriendDataProvider _FriendDataProvider;

	private NavigationSide _pinkPanel = NavigationSide.Left;
	private NavigationSide _greyPanel = NavigationSide.Right;
	private FriendViewModel? _selectedFriend;


	public FriendListViewModel(IFriendDataProvider friendDataProvider)
	{
		_FriendDataProvider = friendDataProvider;
		AddCommand = new DelegateCommand(Add);
		RemoveCommand = new DelegateCommand(Remove, CanRemove);
		MoveNavigationCommand = new DelegateCommand(SwitchPanels);
	}

	public ObservableCollection<FriendViewModel> Friends { get; } = new();
	public FriendViewModel? SelectedFriend
	{
		get => _selectedFriend;
		set
		{
			_selectedFriend = value;
			RaisePropertyChanged();
			RemoveCommand.RaiseCanExecuteChanged();
		}
	}

	public NavigationSide PinkPanel
	{
		get => _pinkPanel;
		private set
		{
			_pinkPanel = value;
			RaisePropertyChanged();
		}
	}

	public NavigationSide GreyPanel
	{
		get => _greyPanel;
		private set
		{
			_greyPanel = value;
			RaisePropertyChanged();
		}
	}

	public DelegateCommand AddCommand { get; }
	public DelegateCommand RemoveCommand { get; }
	public DelegateCommand MoveNavigationCommand { get; }

	public async Task LoadAsync()
	{
		if (Friends.Any()) return;

		var friends = await _FriendDataProvider.GetAllAsync();

		if (friends is null) return;
		foreach (var friend in friends)
		{
			Friends.Add(new FriendViewModel(friend));
		}
	}

	private void Add(object? parameter)
	{
		var newId = Friends.Count == 0 ? 1 : Friends.Max(x => x.ID) + 1;
		var friend = new Friend { ID = newId, Name = "Mitchel", Emoji = "😎" };
		var viewModel = new FriendViewModel(friend);

		Friends.Add(viewModel);
		SelectedFriend = viewModel;
	}

	private bool CanRemove(object? parameter) => SelectedFriend is not null;

	private void Remove(object? parameter)
	{
		if (SelectedFriend is not null)
			Friends.Remove(SelectedFriend);
		SelectedFriend = null;
	}

	private void SwitchPanels(object? parameter)
	{
		switch (PinkPanel)
		{
			case NavigationSide.Left:
				PinkPanel = NavigationSide.Right;
				GreyPanel = NavigationSide.Left;
				break;
			default:
				PinkPanel = NavigationSide.Left;
				GreyPanel = NavigationSide.Right;
				break;
		}
	}

	public enum NavigationSide
	{
		Left,
		Right
	}
}
