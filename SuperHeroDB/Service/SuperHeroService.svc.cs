using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace SuperHeroDB.Service
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SuperHeroService
    {
        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<SuperHero> GetAllHeroes()
        {
            return Data.SuperHeroes;
        }

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetHero/{id}")]
        public SuperHero GetHero(string id)
        {
            return Data.SuperHeroes.Find(sh => sh.Id == int.Parse(id));
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle =WebMessageBodyStyle.Bare, 
            UriTemplate ="AddHero", Method ="POST")]
        public SuperHero AddHero(SuperHero hero)
        {
            hero.Id = Data.SuperHeroes.Max(sh => sh.Id) + 1;
            Data.SuperHeroes.Add(hero);
            return hero;
            }
    }
}
