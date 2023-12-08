namespace National_Water_Commission_App;

public partial class LayoutExample : ContentPage
{
	public LayoutExample()
	{
		InitializeComponent();

		VStackLayout.Padding = DeviceInfo.Platform == DevicePlatform.iOS
			? new Thickness(30, 10, 30, 10) : new Thickness(10);
	}
}