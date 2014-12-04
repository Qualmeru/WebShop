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
        Model.OrderDTO GetOrder(int id);
        [OperationContract]
        List<Model.ProductDTO> GetallProduct();
        [OperationContract]
        Model.ProductDTO Product(int id);
        [OperationContract]
        void AddOrder(Model.OrderDTO order);
        [OperationContract]
        void AddOrderProduct(Model.OrderProductDTO orderProduct);
        [OperationContract]
        string AddCart(Model.CartDTO stock);
        [OperationContract]
        List<Model.CartDTO> GetCartsByuserId(int userId);
        [OperationContract]
        void AddProduct(Model.ProductDTO product);
        [OperationContract]
        void AddGenre(Model.GenreDTO genre);
        [OperationContract]
        void AddConsole(Model.KonsolDTO konsol);
        [OperationContract]
        void DeleteProduct(int id);
    }
}
