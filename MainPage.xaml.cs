using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnOpenCalculatorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalculatorPage());
        }
    }
}
