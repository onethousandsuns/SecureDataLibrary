using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureData.DataHandlers
{
    public abstract class IDataHandler
    {
        public abstract string GetSecuredData(string data);

        public string[] properties { get; set; }
    }
}
