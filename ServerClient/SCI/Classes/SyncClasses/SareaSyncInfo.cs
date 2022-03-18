using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes.SyncClasses
{
    public class LocalSareaSyncInfo
    {
        public string ipAddress { get; set; }
        public Int32 sareaId { get; set; }
        public string bases { get; set; }
        public string userBases { get; set; }
        public string passBases { get; set; }
        public bool isDownload { get; set; }
        public bool isUpload { get; set; }
    }
}
