using System.Linq;
using System.Collections.Generic;
using System;

namespace WordCounterService.Utils
{
    public class Result
    {
        private readonly List<string> _errors = new List<string>();  // The methods could be compacted in one property but it is more natural to read.
                                                                     // Instead of Result.Errors.Add(error) we will have Result.AddError(error)
        private readonly Action<string> logMethod;

        public Result(Action<string> logMethod = null)
        {
            if (logMethod == null) { this.logMethod = d => { }; }
            else { this.logMethod = logMethod; }
        }

        public void AddError(string error)          // I'm ussing this to avoid to many try catch or null references
        {                                           // This class can be extended to have warnings, Info.
            logMethod(error);
            _errors.Add(error);
        }

        public bool HasAnyError()
        {
            return _errors.Any();
        }

        public IEnumerable<string> GetErrors()
        {
            return _errors;
        }
    }
}
