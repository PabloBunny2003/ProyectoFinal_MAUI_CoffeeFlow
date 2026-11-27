
using Microsoft.Maui.Controls;
using ProyectoFinal.App.ViewModels;

namespace ProyectoFinal.App.Views
{
    public partial class ProductosPage : ContentPage
    {
        private readonly ProductosViewModel _viewModel;

        public ProductosPage()
        {
            InitializeComponent();

            _viewModel = new ProductosViewModel();

            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.FiltrarProductos();
        }
    }
}
