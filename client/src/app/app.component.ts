import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Note } from './models/note';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';
  notes: Note[] = [];
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
}

