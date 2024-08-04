namespace Caraspirators.Client.Views;

public partial class CategoriesPage : ContentPage
{
    private CategoriespageViewModel _categoriespageviewmodel;
    public CategoriesPage(CategoriespageViewModel categoriespageviewmodel)
    {
		InitializeComponent();
        _categoriespageviewmodel = categoriespageviewmodel;
        BindingContext = _categoriespageviewmodel;

    }
}