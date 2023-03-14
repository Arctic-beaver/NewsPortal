import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { InputNote } from '../models/inputNote';

@Component({
  selector: 'app-imput-form',
  templateUrl: './imput-form.component.html',
  styleUrls: ['./imput-form.component.css']
})

export class ImputFormComponent implements OnInit {
  model: any = {};
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  postNote(): void {
    console.log(this.model);
    this.model.userName = "Alisa";
    this.model.userEmail = "alisa@yandex.ru";
    this.http.post(this.baseUrl + 'notes/add-note', this.model).subscribe({
      next: result => console.log("Finished pushing", result)
    });
    this.model = {};
  }
}
