using globeChekModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace globeChekServices
{
    public interface IGetClientDetails
    {
        public List<ClientModel> GetClient();
    }
}
