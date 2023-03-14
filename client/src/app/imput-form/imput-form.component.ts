import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-imput-form',
  templateUrl: './imput-form.component.html',
  styleUrls: ['./imput-form.component.css']
})

// interface inputNote {
//   header: string;
//   body: string;
// }

export class ImputFormComponent implements OnInit {

  model: any = {}

  constructor() { }

  ngOnInit(): void {
  }

  postNote(): void {
    console.log(this.model);
  }
}
