using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bonusräknare
{
    // Denna klass representerar en person, med olika data kopplad till sig
    public class Person
    {
        private string namn;
        private string persnr;
        private string distrikt;

        public void AddData(string _namn, string _persnr, string _disktrikt)
        {
            if (_namn != "" && _persnr != "" && _disktrikt != "") 
            {
                namn = _namn;
                persnr = _persnr;
                distrikt = _disktrikt;
            }
            else 
            {
                throw new ArgumentException("Namn, Personnummer och distrikt måste anges");
            }
        }
        public string Namn
        { 
            get 
            { 
                return namn; 
            } 
        }
        public string Persnr
        { 
            get 
            { 
                return persnr; 
            } 
        }
        public string Distrikt
        { 
            get 
            { 
                return distrikt; 
            } 
        }
    }
}
