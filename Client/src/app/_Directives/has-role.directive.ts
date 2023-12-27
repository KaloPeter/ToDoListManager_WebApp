import { Directive, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';
import { UserToken } from '../_Models/userToken';
import { AccountService } from '../_Services/account.service';
import { take } from 'rxjs';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective implements OnInit {

  @Input() appHasRole: string[] = [];//*appHasRole['Admin','Owner']
  user: UserToken = {} as UserToken
  constructor(private viewContainerRef: ViewContainerRef, private templateRef: TemplateRef<any>,
    private accountService: AccountService) {

    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => {
        if (user != null) {
          this.user = user;
        }
      }
    })
  }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe((user) => {
      if (!user) {
        this.viewContainerRef.clear();//Ifthere is no logged user, we do not display content
      } else {

        if (this.appHasRole.some(r => user.roleName)) {
          this.viewContainerRef.createEmbeddedView(this.templateRef);//if there is logged user with desired role, display content
        } else {
          this.viewContainerRef.clear();//if there is logged user, but the neccessery role, do not display content
        }

      }
    })
  }

  //Original
  // ngOnInit(): void {
  //   //user has the required role
  //   //logic comes here
  //   //if the roles we want to check: admin, agent(mentioned above) match with something here, then we show content
  //   console.log(this.user);

  //   // if (this.user?.roles?.some(r => this.appHasRole.includes(r))) {
  //   //   this.viewContainerRef.createEmbeddedView(this.templateRef);
  //   // } else {
  //   //   //user is not in required role
  //   //   this.viewContainerRef.clear();
  //   // }

  // }

}
