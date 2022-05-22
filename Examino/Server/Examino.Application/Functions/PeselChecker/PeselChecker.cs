using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.PeselChecker
{
    public class PeselChecker
    {
        private byte[] PESEL = new byte[11]; 
        private bool isValid = false;

        public PeselChecker(string peselNumber)
        {
            if(peselNumber.Length != 11)
            {
                isValid = false;
            }
            for (int i = 0; i < peselNumber.Length; i++)
            {
                PESEL[i] = byte.Parse(peselNumber.Substring(i, i + 1));
            }
            
        }
    }
}
