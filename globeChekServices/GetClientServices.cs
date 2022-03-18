using globeChekModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace globeChekServices
{

    public class GetClientServices : IGetClientDetails
    {
        private ClientDbContext _ClientDbContext;
        public GetClientServices(ClientDbContext clientDbContext)
        {
            _ClientDbContext = clientDbContext;
        }
        public List<ClientModel> GetClient()
        {
            List<ClientModel> res =  _ClientDbContext.clients.ToList();
            return res.Select(data => new ClientModel
            {
                Name = data.Name
            }).ToList();
        }
    }
}
