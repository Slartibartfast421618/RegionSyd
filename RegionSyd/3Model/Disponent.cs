using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd._3Model
{
    public class Disponent
    {
        private string _regionID;
        public string RegionID { get; }
        private int _disponentNumber;
        public string DisponentID 
        { 
            get { return $"{RegionID}{_disponentNumber}"; } 
        }

        public Disponent(string username)
        {   // Could use both string and int input
            _regionID = username.Substring(0, 2);
            _disponentNumber = int.Parse(username.Substring(2,3));
        }
    }
}
