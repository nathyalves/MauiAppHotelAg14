using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views
{
    public partial class Sobre : ContentPage
    {
        public Sobre()
        {
            InitializeComponent();
        }

        private async void VoltarButton_Clicked(object sender, EventArgs e)
        {
            // Navega de volta para a página inicial
            await Navigation.PopAsync();
        }
    }
}
