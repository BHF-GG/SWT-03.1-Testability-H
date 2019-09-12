using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSH
{
    class Window : IWindow
    {
        private bool _isOpenBool;

        public void Open()
        {
            _isOpenBool = true;
        }

        public void Close()
        {
            _isOpenBool = false;
        }

        public bool IsOpen()
        {
            return _isOpenBool;
        }
    }
}
