import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToDoEventService } from 'src/app/_Services/to-do-event.service';

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

  constructor(private router: Router, private toDoService: ToDoEventService) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];

  }

  choosenDate = new Date();

  ngOnInit(): void {
    this.toDoSingleDateEventModel.toDoSingleEventName = "";
    this.toDoSingleDateEventModel.singleEventImportance = 1;
    this.toDoSingleDateEventModel.toDoSingleEventDescription = "";
    this.toDoSingleDateEventModel.singleEventDate = "";

    this.toDoRangedDateEventModel.toDoRangedEventName = "";
    this.toDoRangedDateEventModel.rangedEventImportance = 1;
    this.toDoRangedDateEventModel.toDoRangedEventDescription = "";
    this.toDoRangedDateEventModel.rangedEventStartDate = "";
    this.toDoRangedDateEventModel.rangedEventEndDate = "";


  }
  singleDatePicker(cd: Date) {
    // let date = cd.toLocaleDateString();

    let y = cd.getFullYear();
    let m = cd.getUTCMonth() + 1;
    let d = cd.getDate();

    let date2 = y + "-" + m + "-" + d;
    this.toDoSingleDateEventModel.singleEventDate = date2;



  }

  rangeDatePicker(cd: any) {
    //let startDate: Date = event[0].toLocaleDateString();
    //let endDate: Date = event[1].toLocaleDateString();
    let y1 = cd[0].getFullYear();
    let m1 = cd[0].getUTCMonth() + 1;
    let d1 = cd[0].getDate();

    let y2 = cd[1].getFullYear();
    let m2 = cd[1].getUTCMonth() + 1;
    let d2 = cd[1].getDate();

    let startDate2 = y1 + "-" + m1 + "-" + d1;
    let endDate2 = y2 + "-" + m2 + "-" + d2;

    this.toDoRangedDateEventModel.rangedEventStartDate = startDate2;
    this.toDoRangedDateEventModel.rangedEventEndDate = endDate2;
  }



  toDoSimpleEventAlerts: AlertType[] = [];
  toDoRangedEventAlerts: AlertType[] = [];

  processSimpleEventForm() {
    let evetnName = this.toDoSingleDateEventModel.toDoSingleEventName;
    let eventImportance = this.toDoSingleDateEventModel.singleEventImportance;
    let eventDescription = this.toDoSingleDateEventModel.toDoSingleEventDescription;

    if (evetnName && eventImportance && eventDescription) {
      //this.addEventSuccessInput(this.toDoSimpleEventAlerts)
      this.toDoService.addToDoSingleEvent(this.toDoSingleDateEventModel).subscribe({
        next: () => this.router.navigateByUrl("/"),
        error: error => this.toDoSimpleEventAlerts.push(
          {
            type: 'Server-Danger-Simple',
            msg: error,
            timeout: 10000
          }
        )
      })
    } else {
      this.addEventWrongInput(this.toDoSimpleEventAlerts);
    }
  }

  processRangedEventForm() {
    let eventName = this.toDoRangedDateEventModel.toDoRangedEventName;
    let eventImportance = this.toDoRangedDateEventModel.rangedEventImportance;
    let eventDescription = this.toDoRangedDateEventModel.toDoRangedEventDescription;

    if (eventName && eventImportance && eventDescription) {
      //this.addEventSuccessInput(this.toDoRangedEventAlerts)
      this.toDoService.addToDoRangedEvent(this.toDoRangedDateEventModel).subscribe({
        next: () => this.router.navigateByUrl("/"),
        error: error => this.toDoRangedDateEventModel.push(
          {
            type: 'Server-Danger-Ranged',
            msg: error,
            timeout: 10000
          }
        )
      })




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
