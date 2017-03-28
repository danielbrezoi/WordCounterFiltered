using WordCounterService.Domain;

namespace WordCounterService.Application.DataFilter
{
    public interface IFilter
    {
        WordCountCollection Filter(WordCountCollection words);
    }
}
