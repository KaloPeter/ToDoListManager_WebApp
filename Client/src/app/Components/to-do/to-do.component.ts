import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-to-do',
  templateUrl: './to-do.component.html',
  styleUrls: ['./to-do.component.css']
})
export class ToDoComponent implements OnInit {

  toDoEventModel: any = {};

  bsInlineValue = new Date();

  date = new Date();


  choosenDate = new Date();

  ngOnInit(): void {
    this.toDoEventModel.eventName = "";
    this.toDoEventModel.eventImportance = "";
    this.toDoEventModel.eventDescription = "";
    this.toDoEventModel.eventDate = "";

  }

  inputEventName(event: any) {
    ;
  }

  onChangeEventImportance(event: any) {
    ;
  }

  inputEventDescription(event: any) {
    ;
  }

  TEST(cd: Date) {
    let date = cd.toLocaleDateString();
    this.toDoEventModel.eventDate = date;
  }

  processEventModel() {
    let evetnName = this.toDoEventModel.eventName;
    let eventImportance = this.toDoEventModel.eventImportance;
    let eventDescription = this.toDoEventModel.eventDescription;




    if (evetnName && eventImportance && eventDescription) {
      console.log(this.toDoEventModel);
    } else {
      console.log("SOMETHING WENT WRONG");

    }


  }
}
