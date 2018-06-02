using AppInicial.Models;
using AppInicial.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppInicial.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrincipalPage : ContentPage
	{
        PrincipalPageViewModel _viewModel;
		public PrincipalPage ()
		{
			InitializeComponent ();
            _viewModel = new PrincipalPageViewModel();
            BindingContext = _viewModel;

            listagem.ItemSelected += Listagem_ItemSelected;
            btnAdicionar.Clicked += BtnAdicionar_Clicked;
		}

        private void Listagem_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelecionado = (Pessoa)e.SelectedItem;
            //Salvando item selecionado
            Helpers.GlobalHelp.PessoaSelecionada = itemSelecionado;

            Navigation.PushAsync(new Views.DetalhePage());
        }

        //Ao clicar em adicionar
        private void BtnAdicionar_Clicked(object sender, EventArgs e)
        {
            //Condicao para preencehr todos os dados. Implementar verificacao de tipo de tado correto, numero de caracters pada cpf etc.
            if (string.IsNullOrEmpty(nomePessoa.Text) || string.IsNullOrEmpty(cpfPessoa.Text))
            {
                //Mostra aviso e retorna (nao deixa o codigo continuar)
                DisplayAlert("Aviso", "Dados ausentes", "Ok");
                return;
            }

            //Recebe o ultimo item digitado
            var lastItem = _viewModel.ListaPessoas.Last();

            //Cria nova variavel Pessoa para inserir as infos
            Pessoa p = new Pessoa
            {
                Id = lastItem.Id + 1,
                Nome = nomePessoa.Text,
                CPF = cpfPessoa.Text
            };

            //Adiciona o objeto a lista
            _viewModel.ListaPessoas.Add(p);

            //limpa campos apos add
            nomePessoa.Text = string.Empty;
            cpfPessoa.Text = string.Empty;
        }
    }
}