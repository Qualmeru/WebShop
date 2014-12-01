using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebShop;

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
        [OperationContract]
        List<Model.KonsolDTO> GetAllConsoles();
        [OperationContract]
        List<Model.GenreDTO> GetAllGenres();
        [OperationContract]
        Order GetOrder(int id);
        [OperationContract]
        List<Model.ProductDTO> GetallProduct();
        [OperationContract]
        Product Product(int id);
        [OperationContract]
        void AddOrder(Model.OrderDTO order);
        [OperationContract]
        void AddOrderProduct(Model.OrderProductDTO orderProduct);
        [OperationContract]
        void AddCart(Model.CartDTO stock);
        [OperationContract]
        Model.CartDTO GetCartById( int userId);
       
    }
}
