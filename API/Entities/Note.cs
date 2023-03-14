
using API.Models;
using API.Helpers;

namespace API.Entities
{
    public class Note : InputNoteModel
    {

        public string Id { get; set; }

        public string CreatedOn { get; set ; }

        public string? LastUpdatedOn { get; set ; }

        public Note(string userName, string userEmail, string header, string body) : base(userName, userEmail, header, body)
        {
            Id = APIHelper.GenerateId();
            CreatedOn = APIHelper.getBeautifulDatetime();
        }

        public Note(InputNoteModel noteModel) : base (noteModel.UserName, noteModel.UserEmail, noteModel.Header, noteModel.Body)
        {
            Id = APIHelper.GenerateId();
            CreatedOn = APIHelper.getBeautifulDatetime();
        }

        public void UpdateNote(InputNoteModel inputNote){
            this.Header = inputNote.Header;
            this.Body = inputNote.Body;
            this.LastUpdatedOn = APIHelper.getBeautifulDatetime();
        }
    }
}