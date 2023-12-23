import { User } from "./user";

export interface ToDoRangedEvent {
    toDoRangedEventName: string,
    toDoRangedEventDescription: string,
    rangedEventImportance: number,
    rangedEventStartDate: Date,
    rangedEventEndDate: Date,
    user: User
}