using App.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace App.Bussiness.Helpers
{
    public class LocalSeqHelper: AppService<LocalSeqHelper>
    {
        private ulong _seq = 1uL;
        //private ulong _record_seq = 0uL;
        private Timer _tmr;
        public ulong NextVal(string seqName = "default")
        {
            bool flag = _tmr == null;
            if (flag)
            {
                _tmr = new Timer(new TimerCallback(TimerCallback), null, 5000, 5000);
            }
            ulong expr_35 = _seq;
            _seq = expr_35 + 1uL;
            return expr_35;
        }
        private void TimerCallback(object state)
        {
            return;
            //日志
            //if (_record_seq == _seq) return;

            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "sequence.log");
            //using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            //{
            //    _record_seq = _seq;
            //    byte[] bytes = Encoding.UTF8.GetBytes(_record_seq.ToString());
            //    fileStream.Write(bytes, 0, bytes.Length);
            //}
        }
    }
}
