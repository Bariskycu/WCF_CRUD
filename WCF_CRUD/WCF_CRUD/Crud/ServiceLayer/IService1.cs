using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLayer
{
    
    [ServiceContract]
    public interface IService1
    {
  
        [OperationContract]
        int InsertProduct(Product p);

        [OperationContract]
        int UpdateProduct(Product p);

        [OperationContract]
        int DeleteProduct(Product p);
        
        [OperationContract]
        List<Product> GetAllProduct();

        
    }

}

