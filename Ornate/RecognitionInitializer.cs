using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornate
{
    class RecognitionInitializer
    {

        public static string[] getDictionary(String path)
        {
            List<Page> _pages = PDFConverter.GetTextFromAllPages(path);
            StringBuilder sBuilder = new StringBuilder();
            foreach (var p in _pages)
            {
                sBuilder.Append(p._content.Trim());
            }
            String cr = sBuilder.ToString();
            String[] _corpus = sBuilder.ToString().Split(' ');
            List<String> crList= _corpus.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            return crList.ToArray<String>();
        }
    }
}
