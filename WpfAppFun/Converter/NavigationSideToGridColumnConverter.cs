using System;
using System.Globalization;
using System.Windows.Data;
using static WpfAppFun.ViewModels.FriendListViewModel;

namespace WpfAppFun.Converter;

public class NavigationSideToGridColumnConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		var navigationSide = (NavigationSide)value;
		return navigationSide == NavigationSide.Left ? 0 : 1;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
