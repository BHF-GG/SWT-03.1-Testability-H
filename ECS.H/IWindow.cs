using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSH
{
    public interface IWindow
    {
        bool IsOpen();
    
        void Open();
        void Close();
    }
}
