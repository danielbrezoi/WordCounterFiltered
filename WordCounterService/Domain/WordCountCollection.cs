using System.Collections.Generic;

namespace WordCounterService.Domain
{
    public class WordCountCollection : SortedDictionary<string,int>
    {
        public void AddToCounter(string key, int addToCount = 1)
        {
            if (this.ContainsKey(key)) { this[key] += addToCount; }
            else { this.Add(key, addToCount); }
        }
    }
}
