import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { ToDoSingleEvent } from '../_Models/toDoSingleEvent';
import { map, single } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ToDoEventService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }


  //Image upload works fine, onyl date is being chnaged probably by the formData
  // upload2(photo: any) {
  //  // const formData = new FormData();
  //   // for (const prop in photo) {
  //   //   //if (!photo.hasOwnProperty(prop)) { continue; }
  //   //   formData.append(prop, photo[prop]);
  //   //   console.log(prop, photo[prop]);
  //   // }

  //   // formData.append("toDoSingleEventName", photo.toDoSingleEventName);
  //   // formData.append("singleEventImportance", photo.singleEventImportance);
  //   // formData.append("toDoSingleEventDescription", photo.toDoSingleEventDescription);
  //   // formData.append("singleEventDate", photo.singleEventDate.toString());
  //   // formData.append("todoimage", photo.todoimage);


  //   return this.http.post<any>(this.baseUrl + "guests/add-todosingleevent", formData);
  // }




  // upload(photo: any) {
  //   return this.http.post<any>(this.baseUrl + "guests/upload", photo);
  // }

  addToDoSingleEvent(singleEvent: any) {
    return this.http.post<ToDoSingleEvent>(this.baseUrl + "guests/add-todosingleevent", singleEvent);
  }


  addToDoRangedEvent(rangedEvent: any) {
    return this.http.post<ToDoSingleEvent>(this.baseUrl + "guests/add-todorangedevent", rangedEvent);
  }


}
