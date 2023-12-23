import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { ToDoSingleEvent } from '../_Models/toDoSingleEvent';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ToDoEventService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }


  addToDoSingleEvent(singleEvent: any) {
    return this.http.post<ToDoSingleEvent>(this.baseUrl + "guests/add-todosingleevent", singleEvent);
  }


  addToDoRangedEvent(rangedEvent: any) {
    return this.http.post<ToDoSingleEvent>(this.baseUrl + "guests/add-todorangedevent", rangedEvent);
  }


}
