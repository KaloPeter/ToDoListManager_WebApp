import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToDoSingleEvent } from '../_Models/toDoSingleEvent';
import { map, of } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { ToDoRangedEvent } from '../_Models/toDoRangedEvent';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  baseUrl = environment.apiUrl;

  toDoSingleEvents: ToDoSingleEvent[] = [];
  toDoRangedEvents: ToDoRangedEvent[] = [];

  constructor(private http: HttpClient) { }


  getToDoSingleEvents() {
    if (this.toDoSingleEvents.length > 0) return of(this.toDoSingleEvents);
    return this.http.get<ToDoSingleEvent[]>(this.baseUrl + "home/get-todosingleevents").pipe(
      map(todos => {
        this.toDoSingleEvents = todos;
        return todos;
      })
    )
  }


  getToDoRangedEvents() {
    if (this.toDoRangedEvents.length > 0) return of(this.toDoRangedEvents);
    return this.http.get<ToDoRangedEvent[]>(this.baseUrl + "home/get-todorangedevents").pipe(
      map(todor => {
        this.toDoRangedEvents = todor;
        return todor;
      })
    )
  }




}
