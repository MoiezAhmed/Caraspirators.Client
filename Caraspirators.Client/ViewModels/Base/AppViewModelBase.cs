using Caraspirators.Client.IServices;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Caraspirators.Client.ViewModels.Base;

public partial class AppViewModelBase : ViewModelBase
{
    public INavigation NavigationService { get; set; }
    public Page PageService { get; set; }
    protected ICategoryService _appApiService { get; set; }



    public AppViewModelBase(ICategoryService appApiService) : base()
    {
        _appApiService = appApiService;
    }

    [RelayCommand]
    private async Task NavigateBack() =>
        await NavigationService.PopAsync();

    [RelayCommand]
    private async Task CloseModal() =>
        await NavigationService.PopModalAsync();

}

