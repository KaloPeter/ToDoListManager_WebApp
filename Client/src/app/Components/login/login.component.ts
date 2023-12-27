import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AlertComponent } from 'ngx-bootstrap/alert';
import { AccountService } from 'src/app/_Services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginModel: any = {};

  constructor(private accountService: AccountService, private router: Router) { }

  @ViewChild(AlertComponent) child: AlertComponent | undefined;

  @ViewChild('alert') alert: any;

  ngOnInit(): void {
    this.loginModel.username = "";
    this.loginModel.password = "";
  }

  login() {
    //************************************************************************************ */
    if (this.loginModel.username == "" || this.loginModel.password == "") {
      this.alert.displayAlert('danger', 'UserName and Password necessary!', 5000);

    }
    else if (this.loginModel.username !== "" && this.loginModel.password !== "") {
      this.accountService.login(this.loginModel).subscribe({
        next: () => this.router.navigateByUrl("home"),
        error: error => {
          this.alert.displayAlert('danger', error.error, 5000);
        }
      })
    }
    else {
      //More than one error message comes from server->collection
      this.accountService.login(this.loginModel).subscribe({
        next: () => this.router.navigateByUrl("/"),
        error: error => {
          this.alert.displayAlert('danger', error.error.errors['Password'][0], 5000);
          this.alert.displayAlert('danger', error.error.errors['UserName'][0], 5000);
        }
      })
    }
  }
}
