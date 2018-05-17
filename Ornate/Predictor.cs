using System;
using System.Collections.Generic;
using System.Text;

//Reference:https://www.codeproject.com/Articles/1157634/Basic-Word-Prediction-in-Csharp

namespace Ornate
{

    public class Predictor
    {
        private readonly Dictionary<string, Dictionary<string, int>>
                  _items = new Dictionary<string, Dictionary<string, int>>();
        private readonly char[] _tokenDelimeter = { ' ' };
        public List<string> Predict(string input)
        {
            var tokens = input.Split(_tokenDelimeter, StringSplitOptions.RemoveEmptyEntries);
            var previousBuilder = new StringBuilder();
            Dictionary<string, int> nextFullList;
            foreach (var token in tokens)
            {
                nextFullList = GetOrCreate(_items, previousBuilder.ToString());
                if (nextFullList.ContainsKey(token))
                    nextFullList[token] += 1;
                else
                    nextFullList.Add(token, 1);

                if (previousBuilder.Length > 0)
                    previousBuilder.Append(" ");
                previousBuilder.Append(token);
            }
            nextFullList = GetOrCreate(_items, previousBuilder.ToString());
            //var prediction = (from x in nextFullList
            //                  orderby x.Value descending
            //                  select x.Key).ToList();

            return new List<string>();
        }
        private static T GetOrCreate<T>(System.Collections.Generic.Dictionary<string, T> d, string key)
        {
            if (d.ContainsKey(key))
            {
                return d[key];
            }
            var t = Activator.CreateInstance<T>();
            d.Add(key, t);
            return t;
        }
    }

}