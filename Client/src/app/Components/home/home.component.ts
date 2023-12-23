import { Component, OnInit } from '@angular/core';
import { ToDoRangedEvent } from 'src/app/_Models/toDoRangedEvent';
import { ToDoSingleEvent } from 'src/app/_Models/toDoSingleEvent';
import { AccountService } from 'src/app/_Services/account.service';
import { HomeService } from 'src/app/_Services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  toDoSingleEvents: ToDoSingleEvent[] = [];
  toDoRangedEvents: ToDoRangedEvent[] = [];

  constructor(private homeService: HomeService, private accountSeervice: AccountService) { }

  ngOnInit(): void {
    this.getToDoSingleEvents();
    this.getToDoRangedEvents();

  }

  getToDoSingleEvents() {
    this.homeService.getToDoSingleEvents().subscribe({
      next: todos => this.toDoSingleEvents = todos
    })
  }

  getToDoRangedEvents() {
    this.homeService.getToDoRangedEvents().subscribe({
      next: todor => this.toDoRangedEvents = todor
    })
  }
}
