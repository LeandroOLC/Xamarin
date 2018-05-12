using App_ConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App_ConsultaCEP.Servico
{
    public class ViaCepServico
    {
		private static string EnderecoURl = "https://viacep.com.br/ws/{0}/json/";

		public static Endereco BuscarEnderecoViaCep(string cep)
		{
			string NovoEnderecoURL = string.Format(EnderecoURl, cep);

			WebClient wc = new WebClient();
			string Conteudo = wc.DownloadString(NovoEnderecoURL);

			Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

			if (end.Cep == null) return null;
			
			return end;
		}
	}
}
