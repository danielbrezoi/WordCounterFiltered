﻿using System;
using WordCounterService;
using WordCounterService.Application.DataReader;
using WordCounterService.Utils;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            var areArgsParseSuccesfull = CommandLine.Parser.Default.ParseArguments(args, options);

            if(areArgsParseSuccesfull)
            {
                var result = new Result(Console.WriteLine);
                var dataReader = new TxtDataReader(options.FilePath);
                var wordsCounterService = new WordsCounterService(dataReader, result, options.Filters);
                var wordsCount = wordsCounterService.GetWordsCounter(options.WordsLenght);

                Console.WriteLine("Word Count:");
                foreach (var word in wordsCount)
                {
                    Console.WriteLine("For the word {0} we have {1} encounters in the data provided.", word.Key, word.Value);
                }
            }
        }
    }
}
