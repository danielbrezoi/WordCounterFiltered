# WordCounterFiltered

[![Travis Build Status](https://travis-ci.org/danielbrezoi/WordCounterFiltered.svg?branch=master)](https://travis-ci.org/danielbrezoi/WordCounterFiltered)

If you run in Visual Studio the next command line arguments are set for both Debug and Release Configuration with AnyCPU:
-p "..\..\fileinput.txt" -f "digits, punctuation, ignorecase, compose" -l "6"

If you want to just count al the words, just replace it with:
-p "..\..\fileinput.txt" -f "digits, punctuation, ignorecase"

The same options can be use for when calling this command line application in cmd.