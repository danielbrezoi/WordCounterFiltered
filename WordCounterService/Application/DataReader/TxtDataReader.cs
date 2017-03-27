using System;
using System.IO;
using System.Collections.Generic;
using WordCounterService.Utils;

namespace WordCounterService.Application.DataReader
{
    public class TxtDataReader : IDataReader
    {
        private string _filePath;
        private string _data;
        private Action<Type, Exception, string, Result> handleException = (exceptionType, exception, data, result) =>
        {
            data = string.Empty;
            var errorDictrionary = new ErrorDictionary();
            result.AddError(errorDictrionary[exceptionType] + exception.StackTrace);
        };

        public TxtDataReader(string filePath)
        {
            _filePath = filePath;
        }

        public string GetData()
        {
            return _data;
        }

        public void ReadData(Result result)
        {
            try
            {
                _data = File.ReadAllText(@_filePath);
            }
            catch (ArgumentException e) { handleException(typeof(ArgumentException), e, _data, result); }
            catch (PathTooLongException e) { handleException(typeof(PathTooLongException), e, _data, result); }
            catch (DirectoryNotFoundException e) { handleException(typeof(DirectoryNotFoundException), e, _data, result); }
            catch (IOException e) { handleException(typeof(IOException), e, _data, result); }
            catch (UnauthorizedAccessException e) { handleException(typeof(UnauthorizedAccessException), e, _data, result); }
            catch (NotSupportedException e) { handleException(typeof(NotSupportedException), e, _data, result); }
            catch (System.Security.SecurityException e) { handleException(typeof(System.Security.SecurityException), e, _data, result); }
            catch (Exception e) { handleException(typeof(Exception), e, _data, result); }

            //This is NOT zombi code! :)
            //This is the C# 7 version 

            //catch (Exception e)
            //{
            // This is posible in C#7 with the new pattern matching.
            // This is not supported with cake builder system yet.
            //switch (e)
            //{
            //    case ArgumentException exception:
            //        result.AddError("Argument exception at: " + exception.StackTrace);
            //        break;
            //    case PathTooLongException exception:
            //        result.AddError("Path is to long at: " + exception.StackTrace);
            //        break;
            //    case DirectoryNotFoundException exception:
            //        result.AddError("Directory not found at: " + exception.StackTrace);
            //        break;
            //    case IOException exception:
            //        result.AddError("IOException not found at: " + exception.StackTrace);
            //        break;
            //    case UnauthorizedAccessException exception:
            //        result.AddError("Unauthorized Access at: " + exception.StackTrace);
            //        break;
            //    case NotSupportedException exception:
            //        result.AddError("Not supported at: " + exception.StackTrace);
            //        break;
            //    case System.Security.SecurityException exception:
            //        result.AddError("Directory not found at: " + exception.StackTrace);
            //        break;
            //    default:
            //        result.AddError("Unknown error at: " + e.StackTrace);
            //        throw e;
            //}
            //}
        }
    }
}
