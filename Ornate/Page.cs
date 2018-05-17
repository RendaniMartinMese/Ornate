using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornate
{
    class Page
    {
        public Page(int number,String content)
        {
            _content = content;
            _number = number;
        }

        public String getHeader()
        {
            String[] header_content = _content.Split('#');
            return header_content[0];
        }
        public String _content { set; get; }
        public String _filtered_content { set; get; }
        public int _number { set; get; }

       


    }
}
