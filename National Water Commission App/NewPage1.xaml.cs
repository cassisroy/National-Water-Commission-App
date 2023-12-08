namespace National_Water_Commission_App;

public partial class NewPage1 : ContentPage
{
	private int count;
	public NewPage1()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
        count++;
        lblCounter.Text = $"Click Count: {count}";

        SemanticScreenReader.Announce(lblCounter.Text);
    }
}