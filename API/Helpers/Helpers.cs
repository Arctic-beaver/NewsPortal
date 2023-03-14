
namespace API.Helpers
{
    public static class APIHelper
    {
        public static string GenerateId()
        {
            const string possible = "ABCDEF1234567890";
            var text = "";
            const string pattern = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";
            Random randomizer = new Random();
            for (int i = 0; i < pattern.Length; i++) {
                if (pattern[i] == 'X') {
                    text += possible[randomizer.Next(0, possible.Length)];
                } else {
                    text += '-';
                }
            }
            return text;
        }

        public static string getBeautifulDatetime() {
            DateTime d = DateTime.Now;
            return $"{d.Hour}:{d.Minute} {d.Day}/{d.Month}/{d.Year}";
        }
    }
}