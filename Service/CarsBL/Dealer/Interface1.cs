using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsBL.Dealer
{
    interface Interface1
    {
        void a();
    }
    interface Interface2
    {
        void a();
    }

    public class b:Interface1,Interface2  
    {
        public void a()
        { 
        
        }
    }
}
