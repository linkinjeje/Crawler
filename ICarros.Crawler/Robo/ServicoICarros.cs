using ICarros.Persistencia.Model;
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
            var objRetorno = this.HttpGet(@"http://www.icarros.com.br/principal/index.jsp");

            objRetorno = this.HttpGet(@"http://www.icarros.com.br/ache/listaanuncios.jsp?bid=0&opcaocidade=1&foa=1&anunciosNovos=1&anunciosUsados=1&marca1=16&modelo1=233&anomodeloinicial=2010&anomodelofinal=2019&precominimo=4000&precomaximo=50000&cidadeaberto=&escopo=2&locationSop=cid_9668.1_-est_SP.1_-esc_2.1_-rai_25.1_");


            var body = objRetorno.DocumentNode.SelectSingleNode("//body");

            var ulListaVertical = body.SelectSingleNode("//*[@id='anunciosForm']/ul");

            var divVeiculos = ulListaVertical.Descendants().Where(_ => _.Attributes["class"] != null && _.Attributes["class"].Value == "anuncio_container false").ToList();

            foreach (var item in divVeiculos)
            {
                var dto = new Carro();

                var nome = item.SelectSingleNode("//div/a/h2/span").InnerText + item.SelectSingleNode("//div/a/h2").InnerText;

                


                dto.Nome = nome;


                retorno.Add(dto);
            }

            return retorno;

        }

    }
}
