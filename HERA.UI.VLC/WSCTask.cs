using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HERA.UI.VLC
{
    public class WSCTask
    {
        public delegate void BackgroundMethodDelegate();
        private BackgroundMethodDelegate _backgroundMethod;
        private Thread _backgroundThread;
        private bool _isRunning;
        private int _timeout;
        public WSCTask(BackgroundMethodDelegate backgroundMethod, int timeout)
        {
            _backgroundMethod = backgroundMethod;
            _timeout = timeout;
        }



        public void Start()
        {
            if (!_isRunning)
            {
                _backgroundThread = new Thread(RunBackgroundMethod);
                _backgroundThread.Start();
                _isRunning = true;
            }
        }



        public void Stop()
        {
            if (_isRunning)
            {
                _backgroundThread.Join();
                _isRunning = false;
            }
        }



        private void RunBackgroundMethod()
        {
            while (_isRunning)
            {
                _backgroundMethod.Invoke();
                Thread.Sleep(_timeout);
            }
        }
    }
}
