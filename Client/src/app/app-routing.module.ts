import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { ToDoComponent } from './Components/to-do/to-do.component';
import { ToDoEventMapComponent } from './Components/to-do-event-map/to-do-event-map.component';
import { authGuard } from './_Guards/auth.guard';
import { guestGuard } from './_Guards/guest.guard';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      { path: 'todomap', component: ToDoEventMapComponent },
      { path: 'add-todo', component: ToDoComponent, canActivate: [guestGuard] },
    ]
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', component: PageNotFoundComponent, pathMatch: 'full' },//"**" means not in the list
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
