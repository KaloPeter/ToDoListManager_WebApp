import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { UserToken } from '../_Models/userToken';
import { BehaviorSubject, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<UserToken | null>(null);
  currentUser$ = this.currentUserSource.asObservable();


  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http
      .post<UserToken>(this.baseUrl + "accounts/login", model)
      .pipe(
        map((response: UserToken) => {
          const user = response;
          if (user) {
            this.currentUserSource.next(user);
            localStorage.setItem('user', JSON.stringify(user))
            this.setRolesForLoggedUser(user);
            this.setCurrentUser(user);
          }
        }
        )
      );
  }

  register(model: any) {
    return this.http.post<UserToken>(this.baseUrl + "accounts/register", model)
      .pipe(
        map(user => {
          if (user) {
            this.currentUserSource.next(user);
            localStorage.setItem('user', JSON.stringify(user))
            //  this.setRolesForLoggedUser(user);
            this.setCurrentUser(user);
          }
          // return user;
        })
      );
  }

  setCurrentUser(user: UserToken) {
    // this.setRolesForLoggedUser(user);
    this.currentUserSource.next(user);
  }

  getCurrentUser() {
    return this.currentUserSource.getValue();
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  setRolesForLoggedUser(user: UserToken) {

    const role = this.getDecodedToken(user.token).role;
    user.roleName = role;
  }

  getDecodedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

}
