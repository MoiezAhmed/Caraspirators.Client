namespace Caraspirators.Client.ViewControls.Common;

public partial class CustomSearchBar : Border
{
    public static readonly BindableProperty IsBarVisiableProperty = BindableProperty.Create(
        "IsBarVisiable",
        typeof(bool),
        typeof(CustomSearchBar),
        false,
        BindingMode.OneWay,
        null,
        SetIsBarVisiable);

    public bool IsBarVisiable
    {
        get => (bool)this.GetValue(IsBarVisiableProperty);
        set => this.SetValue(IsBarVisiableProperty, value);
    }

    private static void SetIsBarVisiable(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as CustomSearchBar).IsVisible = (bool)newValue;
    }

    public CustomSearchBar()
	{
		InitializeComponent();
	}
}