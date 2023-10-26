using MonkeyFinder.ViewModel;

namespace MonkeyFinder;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(MonkeysViewModel monkeysViewModel)
	{
		InitializeComponent();
		BindingContext = monkeysViewModel;
	}

	
}

