
namespace Caraspirators.Client.Views;

public partial class HomePage : ViewBase<HomePageViewModel>
{
    
    public HomePage()
	{

        InitializeComponent();
        
        
	}
    private void OnScrolled(object sender, ScrolledEventArgs e)
    {
        // Pass the current scrollY value to the ViewModel method
        ((HomePageViewModel)BindingContext).OnScrolled(e.ScrollY);
    }
}