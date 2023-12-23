import { Component, Input } from '@angular/core';
import { ToDoRangedEvent } from 'src/app/_Models/toDoRangedEvent';
import { ToDoSingleEvent } from 'src/app/_Models/toDoSingleEvent';

@Component({
  selector: 'app-to-do-event-card',
  templateUrl: './to-do-event-card.component.html',
  styleUrls: ['./to-do-event-card.component.css']
})
export class ToDoEventCardComponent {


  @Input() inputToDoSingleEvent: ToDoSingleEvent | undefined;

  @Input() inputToDoRangedEvent: ToDoRangedEvent | undefined;



}
