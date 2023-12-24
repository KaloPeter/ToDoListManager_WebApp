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
      this.alert.displayAlert('danger', 'Wrong input data-LOGIN', 5000);
    } else {
      this.accountService.login(this.loginModel).subscribe({
        next: () => this.router.navigateByUrl("/"),
        error: error => this.alert.displayAlert('danger', error.error, 5000)
      })
      //this.alert.displayInvalidFormAlert('success', 'Wrong input data-LOGIN', 5000);

    }
  }
}
