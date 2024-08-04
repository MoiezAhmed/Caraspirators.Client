
using System.Net.Http;

namespace TestQueenApp.Client
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthService  _authService;

        public MainPage(IHttpClientFactory httpClientFactory, IAuthService authService)
        {
            _httpClientFactory = httpClientFactory;
            InitializeComponent();
            _authService = authService;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            if (await _authService.IsUserAuthenticated())
            {
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(SigninPage)}");
            }
        }

        //private async void OnGetDataFromApiClicked(object sender, EventArgs e)
        //{
        //    //http://10.0.2.2:5220/api/Categories/Api/V1/Category/Paginated
        //    var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
        //    var response = await httpClient.GetAsync("/api/Categories/Api/V1/Category/Paginated");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        label.Text = content;
        //    }
        //}
    }

}
