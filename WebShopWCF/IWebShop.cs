using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
namespace WebShopWCF
{
    [ServiceContract]
    public interface IWebShop
    {
        [OperationContract]
        void Register(Model.PersonDTO person);
        [OperationContract]
        List<Model.OrderDTO> GetOrderList();
        [OperationContract]
        Model.PersonDTO FindUser(string userName);
    }
}
