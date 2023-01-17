using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyConsole
{
    public class MathLib:IDisposable
    {
       /*basic örnek */
        public bool IsDisposed { get; private set; }=false;
        public void Dispose()
        {
            IsDisposed=true;
        }

        public void Show()
        {
            Console.WriteLine(IsDisposed);
        }
    }
}
