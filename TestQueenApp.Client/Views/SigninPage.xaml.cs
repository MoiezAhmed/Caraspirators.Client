namespace TestQueenApp.Client.Views;

public partial class SigninPage : ContentPage
{

    private readonly IAuthService _authService;
    public SigninPage(IAuthService authService)
	{
		InitializeComponent();
        _authService = authService;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var user = new SiginRequest();
        user.UserName = "moiez";
        user.Password = "Moiez*009";
        var (data, succeeded, message) = await _authService.SigninAsync(user);
      //  var error = await _authService.LoginAsync(new Shared.Models.LoginRequestDto("Username", "password"));
        if (succeeded)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", message, "Ok");
        }
    }
}