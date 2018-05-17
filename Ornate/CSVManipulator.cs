using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornate
{
    class CSVManipulator
    {

        public DataTable lazyReady(String path)
        {
            var dt = DataTable.New.ReadLazy(path);
            return dt;
        }
        public DataTable lazyReadExcel(String path)
        {
            var dt = DataTable.New.ReadLazy(path);
            return dt;
        }

    }
}
