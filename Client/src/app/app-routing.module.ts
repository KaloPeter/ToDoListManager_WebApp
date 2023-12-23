import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { ToDoComponent } from './Components/to-do/to-do.component';
import { ToDoEventMapComponent } from './Components/to-do-event-map/to-do-event-map.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'todo', component: ToDoComponent },
  { path: 'todomap', component: ToDoEventMapComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },//"**" means not in the list
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
