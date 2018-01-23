using ICarros.Persistencia.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICarros.Crawler.Robo
{
    public class ServicoICarros : Robo
    {
        public ServicoICarros()
        {
            RoboWebClient = new RoboWebClient();
        }

        public List<Carro> ExtrairDadosCarros()
        {
            var retorno = new List<Carro>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            this.RoboWebClient._allowAutoRedirect = false;
            //var objRetorno = this.HttpGet(@"http://www.icarros.com.br/principal/index.jsp");

            var objRetorno = this.HttpGet(@"http://www.icarros.com.br/ache/listaanuncios.jsp?bid=0&opcaocidade=1&foa=1&anunciosNovos=1&anunciosUsados=1&marca1=16&modelo1=233&anomodeloinicial=2010&anomodelofinal=2019&precominimo=4000&precomaximo=50000&cidadeaberto=&escopo=2&locationSop=cid_9668.1_-est_SP.1_-esc_2.1_-rai_25.1_");


            var body = objRetorno.DocumentNode.SelectSingleNode("//body");

            var ulListaVertical = body.SelectSingleNode("//*[@id='anunciosForm']/ul");

            var divVeiculos = ulListaVertical.Descendants().Where(_ => _.Attributes["class"] != null && _.Attributes["class"].Value == "anuncio_container false").ToList();

            foreach (var item in divVeiculos)
            {
                var dto = new Carro();

                //var nome = item.SelectSingleNode("//ul/li/div/a/h2/span").InnerText +" "+ item.SelectSingleNode("//ul/li/div/a/h2/").InnerText;///*[@id="ac16007790"]/div/a/h2/text()
                var nome = item.SelectSingleNode(".//a[@class ='clearfix']/h2").InnerText;
                var ano = item.SelectSingleNode(".//a[@class ='clearfix']/ul/li/p").InnerText;
                var km  = item.SelectSingleNode(".//div[1]/a/ul/li[2]/p").InnerText.Replace("\r\n", "").Replace(" ", "");
                var cor =item.SelectSingleNode(".//a[@class ='clearfix']/ul/li[3]/p").InnerText;
                var cambio = item.SelectSingleNode(".//a[@class ='clearfix']/ul/li[4]/p").InnerText;
                var valor = item.SelectSingleNode(".//a[@class ='clearfix']/h3").InnerText.ToString();


                dto.Nome = nome;
                dto.Ano = ano;
                dto.Km = km;
                dto.Cor = cor;
                dto.Cambio = cambio;
                dto.Valor = Convert.ToDecimal(valor.Replace("R$", ""));




                retorno.Add(dto);
            }

            return retorno;

        }

    }
}
