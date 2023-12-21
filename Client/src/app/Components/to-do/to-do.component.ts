import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-to-do',
  templateUrl: './to-do.component.html',
  styleUrls: ['./to-do.component.css']
})
export class ToDoComponent implements OnInit {

  toDoSingleDateEventModel: any = {};

  toDoRangedDateEventModel: any = {};

  bsInlineValue = new Date();
  date = new Date();

  bsInlineRangeValue: Date[];
  maxDate = new Date();

  constructor() {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];

  }

  choosenDate = new Date();

  ngOnInit(): void {
    this.toDoSingleDateEventModel.eventName = "";
    this.toDoSingleDateEventModel.eventImportance = 1;
    this.toDoSingleDateEventModel.eventDescription = "";
    this.toDoSingleDateEventModel.eventDate = "";

    this.toDoRangedDateEventModel.eventName = "";
    this.toDoRangedDateEventModel.eventImportance = 1;
    this.toDoRangedDateEventModel.eventDescription = "";
    this.toDoRangedDateEventModel.eventStartDate = "";
    this.toDoRangedDateEventModel.eventEndDate = "";

    // this.toDoEventModel.eventStartDate = "";
    // this.toDoEventModel.eventEndDate = "";

  }
  singleDatePicker(cd: Date) {
    let date = cd.toLocaleDateString();
    this.toDoSingleDateEventModel.eventDate = date;
  }

  rangeDatePicker(event: any) {
    let startDate: Date = event[0].toLocaleDateString();
    let endDate: Date = event[1].toLocaleDateString();

    this.toDoRangedDateEventModel.eventStartDate = startDate;
    this.toDoRangedDateEventModel.eventEndDate = endDate;

    // console.log(startDate);
    //  console.log(endDate);
  }



  toDoSimpleEventAlerts: AlertType[] = [];
  toDoRangedEventAlerts: AlertType[] = [];

  processSimpleEventForm() {
    let evetnName = this.toDoSingleDateEventModel.eventName;
    let eventImportance = this.toDoSingleDateEventModel.eventImportance;
    let eventDescription = this.toDoSingleDateEventModel.eventDescription;

    if (evetnName && eventImportance && eventDescription) {
      this.addEventSuccessInput(this.toDoSimpleEventAlerts)
    } else {
      this.addEventWrongInput(this.toDoSimpleEventAlerts);
    }
  }

  processRangedEventForm() {
    let eventName = this.toDoRangedDateEventModel.eventName;
    let eventImportance = this.toDoRangedDateEventModel.eventImportance;
    let eventDescription = this.toDoRangedDateEventModel.eventDescription;




    if (eventName && eventImportance && eventDescription) {
      this.addEventSuccessInput(this.toDoRangedEventAlerts)
    } else {
      this.addEventWrongInput(this.toDoRangedEventAlerts);
    }
  }

  /********************************** */

  addEventWrongInput(array: AlertType[]): void {
    if (array.length < 2) {
      array.push({
        type: 'danger',
        msg: 'The form is invalid, because one or more inputs are not correct!',
        timeout: 5000
      });
    }

  }

  addEventSuccessInput(array: AlertType[]): void {
    if (array.length < 2) {
      array.push({
        type: 'success',
        msg: 'The event is being proceessed!',
        timeout: 5000
      });
    }
  }

  onClosedSimpleEventAlert(dismissedAlert: AlertType): void {
    this.toDoSimpleEventAlerts = this.toDoSimpleEventAlerts.filter((alert) => alert !== dismissedAlert);
  }

  onClosedRangedEventAlert(dismissedAlert: AlertType): void {
    this.toDoRangedEventAlerts = this.toDoRangedEventAlerts.filter((alert) => alert !== dismissedAlert);
  }

}
type AlertType = { type: string; msg: string; timeout: number };
