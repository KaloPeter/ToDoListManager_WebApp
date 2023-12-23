import { User } from "./user";

export interface ToDoSingleEvent {
    toDoSingleEventName: string,
    toDoSingleEventDescription: string,
    singleEventImportance: number,
    singleEventDate: Date,
    user: User

}