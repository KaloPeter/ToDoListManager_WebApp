import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserToken } from 'src/app/_Models/userToken';
import { AccountService } from 'src/app/_Services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  loggedUserObs: Observable<UserToken | null> | null = null;
  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.loggedUserObs = this.accountService.currentUser$
  }



  signIn() {
    this.router.navigateByUrl('/login');
  }

  signUp() {
    this.router.navigateByUrl('/register');
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/home');
  }

}
