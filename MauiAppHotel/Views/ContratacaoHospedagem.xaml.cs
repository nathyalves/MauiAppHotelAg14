using System;
using System.Windows.Input;
using MauiAppHotel.Views;

namespace MauiAppHotel.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        public ICommand NavigateToSobreCommand { get; }
        App PropriedadesApp;

        public ContratacaoHospedagem()
        {
            InitializeComponent();

            // Inicializa o comando de navegação para a página 'Sobre'
            NavigateToSobreCommand = new Command(async () => await Navigation.PushAsync(new Sobre()));
            BindingContext = this;

            // Configurações adicionais da aplicação
            PropriedadesApp = (App)Application.Current;
            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

            // Configurações de data mínima e máxima para check-in e check-out
            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

            dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
            dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Navega para a página 'HospedagemContratada'
                Navigation.PushAsync(new HospedagemContratada());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker elemento = sender as DatePicker;
            DateTime data_selecionada_checkin = elemento.Date;

            // Ajusta as datas permitidas para o check-out com base no check-in selecionado
            dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
            dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
        }
    }
}


