using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public abstract class BaseViewBLL : IDisposable
    {
        protected SysEntities db = new SysEntities();
        public void Dispose()
        {

        }
    }
}
