
using Microsoft.Maui.Controls;
using ProyectoFinal.App.ViewModels;

namespace ProyectoFinal.App.Views
{
    public partial class DashboardPage : ContentPage
    {
        private readonly DashboardViewModel _viewModel;

        public DashboardPage()
        {
            InitializeComponent();

            _viewModel = new DashboardViewModel();

            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.ActualizarIndicadores();
        }
    }
}
