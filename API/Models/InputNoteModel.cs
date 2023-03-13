
namespace API.Models
{
    [Serializable]
    public class InputNoteModel
    {
        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }

        public InputNoteModel(string userName, string userEmail, string header, string body)
        {
            UserName = userName;
            UserEmail = userEmail;
            Header = header;
            Body = body;
        }
    }
}