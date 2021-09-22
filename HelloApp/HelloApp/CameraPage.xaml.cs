using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloApp
{
    public partial class CameraPage : ContentPage
    {
        ApplicationViewModel viewModel;

        public CameraPage()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetCameras();
            base.OnAppearing();
        }
    }
}