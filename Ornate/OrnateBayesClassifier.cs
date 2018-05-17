using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornate
{
    class OrnateBayesClassifier
    {

        private BayesClassifier contentClassifier;
        public Dictionary<String, String> _dataset { set; get; }

        public Boolean trainDataset()
        {
            String[] keysArray = _dataset.Keys.ToArray();
            keysArray = keysArray.Select(s => s.ToLowerInvariant()).ToArray();
            contentClassifier = new BayesClassifier(keysArray);
            String[] valuesArray = _dataset.Values.ToArray();
            for (int c = 0; c < valuesArray.Length; c++)
            {
                contentClassifier.Train(keysArray[c], valuesArray[c]);
            }
            return true;
        }
        public List<String> classify(List<String> sampleData)
        {

            List<String> tempList = new List<String>();
            foreach (var s in sampleData)
            {
                tempList.Add(contentClassifier.Classify(s));
            }
            return tempList;
        }
        public OrnateBayesClassifier() { }
    }

}
