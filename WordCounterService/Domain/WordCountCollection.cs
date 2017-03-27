using System.Collections.Generic;

namespace WordCounterService.Domain
{
    public class WordCountCollection : SortedDictionary<string,int>
    {
        public void AddToCounter(string key)
        {
            if (this.ContainsKey(key)) { this[key] += 1; }
            else { this.Add(key, 1); }
        }
    }
}
