using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DBSystemTP.Entities.Models;


namespace DBSystemTP.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceUsuario" in both code and config file together.
    [ServiceContract]
    public interface IServiceUsuario
    {
        [OperationContract]
        Usuario find(int id);
    }
}
