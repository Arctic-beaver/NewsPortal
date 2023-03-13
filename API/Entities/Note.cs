
using API.Models;

namespace API.Entities
{
    public class Note : InputNoteModel
    {

        public string Id { get; set; }

        public string CreatedOn { get; set ; }

        public Note(string userName, string userEmail, string header, string body) : base(userName, userEmail, header, body)
        {
            Id = GenerateId();
            CreatedOn = getBeautifulDatetime();
        }

        public Note(InputNoteModel noteModel) : base (noteModel.UserName, noteModel.UserEmail, noteModel.Header, noteModel.Body)
        {
            Id = GenerateId();
            CreatedOn = getBeautifulDatetime();
        }

        private string GenerateId()
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

        private string getBeautifulDatetime() {
            DateTime d = DateTime.Now;
            return $"{d.Hour}:{d.Minute} {d.Day}/{d.Month}/{d.Year}";
        }
    }
}