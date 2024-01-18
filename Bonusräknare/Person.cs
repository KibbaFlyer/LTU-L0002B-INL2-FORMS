using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bonusräknare
{
    internal class Person
    {
        private string namn;
        private string persnr;
        private string distrikt;

        public object AddData(string _namn, string _persnr, string _disktrikt)
        {
            if (_namn != null && _persnr != null && _disktrikt != null) 
            {
                namn = _namn;
                persnr = _persnr;
                distrikt = _disktrikt;
                return this;
            }
            else 
            { //error
                throw new InvalidOperationException("Namn, Personnummer och distrikt måste anges");
            }
        }
    }
}
