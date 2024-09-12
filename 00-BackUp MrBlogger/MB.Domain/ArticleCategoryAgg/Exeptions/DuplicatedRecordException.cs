namespace MB.Domain.ArticleCategoryAgg.Exeptions
{
    public class DuplicatedRecordException : Exception
    {
        public DuplicatedRecordException()
        {
        }

        public DuplicatedRecordException(string message) : base(message)
        {

        }
    }
}
