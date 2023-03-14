import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Note } from '../models/note';


@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.css']
})
export class EditNoteComponent implements OnInit {

  notes: Note[] = [];
  editingNote: Note = this.GetDefaultNote();
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get(this.baseUrl + 'notes').subscribe({
      next: response => {
        this.notes = (response as any[]).reverse();
        console.log(response);
      },
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })
  }

  Edit(note: Note){
    this.editingNote = this._clone(note);
    console.log(this.editingNote);
  }

  UpdateNote(): void {
    console.log(this.editingNote);
    // this.http.post(this.baseUrl + 'notes/update-note', this.editingNote).subscribe({
    //   next: result => console.log("Finished pushing", result)
    // });
    this.editingNote = this.GetDefaultNote();;
  }

  ResetNote(): void {
    this.editingNote = this.GetDefaultNote();;
  }

  private _clone(obj: any){
    if (obj === null || typeof (obj) !== 'object' || 'isActiveClone' in obj)
        return obj;

    let temp : any;
    if (obj instanceof Date)
        temp = new Date(obj);
    else
        temp = obj.constructor();

    for (var key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
            obj['isActiveClone'] = null;
            temp[key] = this._clone(obj[key]);
            delete obj['isActiveClone'];
        }
    }
    return temp;
  }

  private GetDefaultNote(): Note {
    let defaultNote : Note = {
      header: "",
      body: "",
      id: "",
      createdOn: "",
      userName: "",
      userEmail: ""
    }
    return defaultNote;
  }
}
