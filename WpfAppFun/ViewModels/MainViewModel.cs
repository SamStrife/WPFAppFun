using System.Threading.Tasks;
using WpfAppFun.Commands;

namespace WpfAppFun.ViewModels;

public class MainViewModel : ViewModelBase
{
	private ViewModelBase? _selectedViewModel;

	public MainViewModel(FriendListViewModel friendListViewModel, GamesViewModel gamesViewModel)
	{
		FriendListViewModel = friendListViewModel;
		GamesViewModel = gamesViewModel;
		SelectedViewModel = FriendListViewModel;
		SelectViewModelCommand = new DelegateCommand(SelectViewModel);
	}

	public ViewModelBase? SelectedViewModel
	{
		get => _selectedViewModel;
		set
		{
			_selectedViewModel = value;
			RaisePropertyChanged();
		}
	}

	public FriendListViewModel FriendListViewModel { get; }
	public GamesViewModel GamesViewModel { get; }
	public DelegateCommand SelectViewModelCommand { get; }

	public async override Task LoadAsync()
	{
		if (SelectedViewModel is not null)
		{
			await SelectedViewModel.LoadAsync();
		}
	}

	private async void SelectViewModel(object? parameter)
	{
		SelectedViewModel = parameter as ViewModelBase;
		await LoadAsync();
	}

}
