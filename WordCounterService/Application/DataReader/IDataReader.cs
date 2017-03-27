using WordCounterService.Utils;

namespace WordCounterService.Application.DataReader
{
    public interface IDataReader
    {
        void ReadData(Result result);
        string GetData();
    }
}
