import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_Services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginModel: any = {};

  constructor(private accountService: AccountService, private router: Router) { }


  login() {
    this.accountService.login(this.loginModel).subscribe({
      next: () => this.router.navigateByUrl("/"),
      error: error => console.log(error)

    })
  }
}
