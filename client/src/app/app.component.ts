import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';
  notes: any;
  
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:7036/api/notes').subscribe({
      next: response => this.notes = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })
  }
}
