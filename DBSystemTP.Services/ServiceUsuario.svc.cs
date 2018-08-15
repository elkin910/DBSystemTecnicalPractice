using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DBSystemTP.Data;
using DBSystemTP.Entities.Models;

namespace DBSystemTP.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceUsuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceUsuario.svc or ServiceUsuario.svc.cs at the Solution Explorer and start debugging.
    public class ServiceUsuario : IServiceUsuario
    {
        private DBSystemContext db = new DBSystemContext();
        public Usuario find(int id)
        {

            var usuario = db.Usuarios.Find(id);
            return usuario;
        }
    }
}
