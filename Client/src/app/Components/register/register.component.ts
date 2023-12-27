import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_Services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  registerModel: any = {};

  constructor(private accountService: AccountService, private router: Router) { }


  @ViewChild('alert') alert: any;


  ngOnInit(): void {
    this.registerModel.firstName = "";
    this.registerModel.lastName = "";
    this.registerModel.email = "";
    this.registerModel.username = "";
    this.registerModel.password = "";

  }

  register() {
    let fn = this.registerModel.firstName == "" ? true : false
    let ln = this.registerModel.lastName == "" ? true : false
    let em = this.registerModel.email == "" ? true : false
    let un = this.registerModel.username == "" ? true : false
    let ps = this.registerModel.password == "" ? true : false

    if (fn || ln || em || un || ps) {
      this.alert.displayAlert('danger', 'Every input is necessary!', 5000);
    }
    else {
      this.accountService.register(this.registerModel).subscribe(
        {
          next: () => this.router.navigateByUrl("/"),
          error: err => this.alert.displayAlert('danger', err.error, 5000)
        }
      )
    }


  }


}
