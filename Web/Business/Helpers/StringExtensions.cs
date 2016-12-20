
namespace Business.Helpers
{
    public static class StringExtensions
    {
        public static int ToInt(this string myString)
        {
            int value;
            int.TryParse(myString, out value);

            return value;
        }
    }
}
