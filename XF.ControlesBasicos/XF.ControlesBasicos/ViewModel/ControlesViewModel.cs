using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.ControlesBasicos;


namespace XF.ControlesBasicos.ViewModel
{
    public class ControlesViewModel : INotifyPropertyChanged
    {
        public ICommand OnEnviar { get; set; }

        public ICommand OnConfiguracao { get; set; }

        private bool ativo;

        public bool Ativo
        {
            get
            {
                return ativo;
            }
            set
            {
                ativo = value;
                if (!ativo)
                {
                    Email = string.Empty;
                }
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnAlterarPropriedade("email");
            }
        }



        public ControlesViewModel()
        {
            OnEnviar = new Command(Enviar);
            OnConfiguracao = new Command(IrConfiguracao);
        }


        public void Enviar()
        {
            App.Current.MainPage.DisplayAlert("Mensagem","E-mail enviado para","Ok");

        }

        public void IrConfiguracao()
        {
            App.Current.MainPage.Navigation.PushAsync(new ConfigView() { BindingContext = App.ControlesVM }); 
        }

    }

    public interface INotifyPropertyChanged
    {
    }
}
