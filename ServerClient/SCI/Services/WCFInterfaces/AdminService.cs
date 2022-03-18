using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ZPSoft.GameZone.DatabaseComponents;
using ZPSoft.GameZone.SGZGlobals.DataSets;
using ZPSoft.GameZone.SGZWCFInterfaces;
using ZPSoft.GameZone.SGZWCFInterfaces.Classes;

namespace ZPSoft.GameZone.SCI.Services.WCFInterfaces
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class AdminService : IGameZoneService
    {
        public void ConnectClient(ConnectedUserClass userPrincipal)
        {
            //throw new NotImplementedException();
        }

        public void PingConnection(Guid programIdentificator)
        {
            //throw new NotImplementedException();
        }

        protected DataSetHolder holder = null;
        public void SaveAdminData(GameZoneDataSet data)
        {
            holder = new DataSetHolder();
            lock (holder)
            {
                holder.Data = data;
                holder.SaveAll();
                holder.ClearAll();
            }
        }
    }
}
