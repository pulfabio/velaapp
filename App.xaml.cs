using velaapp.Views;

namespace velaapp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
        MainPage = new HomePage(); //Issues with ZXing
    }
}

