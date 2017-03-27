using CommandLine;
using CommandLine.Text;
using System.Collections.Generic;
using WordCounterService.Application.DataFilter;

namespace WordCounter
{
    public class Options
    {
        private string _filterType;
        private List<FiltersEnum> _filters = new List<FiltersEnum>();
        private Dictionary<string, FiltersEnum> _filtersMaps = new Dictionary<string, FiltersEnum>()
            {
                { "", FiltersEnum.Empty },
                { "digits", FiltersEnum.Digits },
                { "punctuation", FiltersEnum.Punctuation },
                { "ignorecase", FiltersEnum.IgnoreCase },
                { "compose", FiltersEnum.Compose }
            };


        [Option(shortName: 'p', longName:"filePath", Required = false, HelpText = "Full path to data file.")]
        public string FilePath { get; set; }

        [Option(shortName: 'l', longName: "lenght", Required = false, HelpText = "If a value is prrovidet, only words with this lenght will be count)")]
        public int WordsLenght { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }

        [Option(shortName: 'f', longName: "filterType", Required = false, HelpText = "Provide multiple filter type(digits, compose, puctuation, ignorecase)")]
        public string Filter
        {
            get { return _filterType; }
            set
            {
                var filters = value.Trim().ToLower().Split(',');
                foreach (var filter in filters)
                {
                    if (_filtersMaps.ContainsKey(value)) { _filters.Add(_filtersMaps[filter]); }
                    else { throw new System.Exception(message: string.Format("Filter: {0} is not supported!", value)); }
                }
            }
        }

        public IEnumerable<FiltersEnum> Filters { get { return _filters; } }
    }
}
