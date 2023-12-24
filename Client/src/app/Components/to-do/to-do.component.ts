import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AlertType } from 'src/app/_Models/AlertType';
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

  @ViewChild('singleAlert') singleAlert: any;
  @ViewChild('rangedAlert') rangedAlert: any;

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
    let y = cd.getFullYear().toString();
    let m = (cd.getUTCMonth() + 1) < 10 ? "0" + (cd.getUTCMonth() + 1) : (cd.getUTCMonth() + 1).toString();
    let d = cd.getDate() < 10 ? "0" + cd.getDate() : cd.getDate().toString();

    let date2 = y + "-" + m + "-" + d;
    this.toDoSingleDateEventModel.singleEventDate = date2;

  }

  rangeDatePicker(cd: any) {
    let y1 = cd[0].getFullYear().toString();
    let m1 = parseInt(cd[0].getUTCMonth()) + 1 < 10 ? "0" + (parseInt(cd[0].getUTCMonth()) + 1) : (parseInt(cd[0].getUTCMonth()) + 1).toString();
    let d1 = parseInt(cd[0].getDate()) < 10 ? "0" + cd[0].getDate() : cd[0].getDate().toString();

    let y2 = cd[1].getFullYear();
    let m2 = parseInt(cd[1].getUTCMonth()) + 1 < 10 ? "0" + (cd[1].getUTCMonth() + 1) : (cd[1].getUTCMonth() + 1).toString();
    let d2 = parseInt(cd[1].getDate()) < 10 ? "0" + cd[1].getDate() : cd[1].getDate().toString();

    let startDate2 = y1 + "-" + m1 + "-" + d1;
    let endDate2 = y2 + "-" + m2 + "-" + d2;

    this.toDoRangedDateEventModel.rangedEventStartDate = startDate2;
    this.toDoRangedDateEventModel.rangedEventEndDate = endDate2;
  }


  processSimpleEventForm() {
    let evetnName = this.toDoSingleDateEventModel.toDoSingleEventName;
    let eventImportance = this.toDoSingleDateEventModel.singleEventImportance;
    let eventDescription = this.toDoSingleDateEventModel.toDoSingleEventDescription;

    if (evetnName && eventImportance && eventDescription) {
      this.toDoService.addToDoSingleEvent(this.toDoSingleDateEventModel).subscribe({
        next: () => this.router.navigateByUrl("/"),
        error: error => this.singleAlert.displayAlert('danger', error.error, 5000)
      })
    } else {
      this.singleAlert.displayAlert('danger', "The form is invalid, because one or more inputs are not correct!-SIMPLE", 5000)
    }
  }

  processRangedEventForm() {
    let eventName = this.toDoRangedDateEventModel.toDoRangedEventName;
    let eventImportance = this.toDoRangedDateEventModel.rangedEventImportance;
    let eventDescription = this.toDoRangedDateEventModel.toDoRangedEventDescription;

    if (eventName && eventImportance && eventDescription) {

      this.toDoService.addToDoRangedEvent(this.toDoRangedDateEventModel).subscribe({
        next: () => this.router.navigateByUrl("/"),
        error: error => this.rangedAlert.displayAlert('danger', error.error, 5000)

      })


    } else {
      this.rangedAlert.displayAlert('danger', "The form is invalid, because one or more inputs are not correct!-RANGED", 5000);
    }
  }


}
