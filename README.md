# WordCounterFiltered

[![Travis Build Status](https://travis-ci.org/danielbrezoi/WordCounterFiltered.svg?branch=master)](https://travis-ci.org/danielbrezoi/WordCounterFiltered)
For this project I use Travis as a CI. Just click the build status image to go to build page.

The project structure follows the domain driven desing approach has three main components:
- the UI layer is implemented through the WordCounter command line application;
- the Application layer is implemented in the WordCounterService project, in WordCounterService.Application namespace;
- the Domain layer is implemented in the WordCounterService projec, in WordCounterService.Domain namespace. 
For a better understanding of the implementation design there is a code mape in the root folder 

If you run in Visual Studio the next command line arguments are set for both Debug and Release Configuration with AnyCPU:
-p "..\..\fileinput.txt" -f "digits, punctuation, ignorecase, compose" -l "6"

If you want to just count al the words, just replace it with:
-p "..\..\fileinput.txt" -f "digits, punctuation, ignorecase"

The same options can be use for when calling this command line application in cmd.
Int the WordCounterService.Application.DataReader.TxtDataReader.cs there is a sample of C# 7. Because of the Travis CI that it is working on linux it was more dificult to use the latest technologies from Microsoft. 
