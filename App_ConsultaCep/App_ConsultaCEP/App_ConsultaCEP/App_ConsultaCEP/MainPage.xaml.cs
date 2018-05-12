using App_ConsultaCEP.Servico;
using App_ConsultaCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_ConsultaCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BOTAO.Clicked += BuscarCEP;
		}

		public void BuscarCEP(Object sender, EventArgs args)
		{
			string cep = CEP.Text.Trim();

			if (isValidCEP(cep))
			{
				try
				{
					Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);

					if(end != null)
					{
						RESULTADO.Text = string.Format("Endereco: {2} de {3},{0},{1}", end.Localidade, end.Uf, end.Logradouro, end.Bairro);
					}
					else
					{
						DisplayAlert("ERRO ","Endereço não foi encontrado", "OK");
					}

				}
				catch (Exception e )
				{

					DisplayAlert("ERRO CRÌTICO",e.Message,"OK");
				}
			}
		}
		private bool isValidCEP(string cep)
		{
			bool valido = true;

			if (cep.Length != 8)
			{
				DisplayAlert("ERRO", "Cep inválido! O CEP deve conter 8 caracteres.", "OK");

				valido = false;
			}
			int NovoCEP = 0;
			if(!int.TryParse(cep, out NovoCEP))
			{
				DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas po números.", "OK");

				valido = false;
			}

			return valido;
		}
	}
}
