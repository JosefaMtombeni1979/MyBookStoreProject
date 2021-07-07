import { MatDialog } from '@angular/material/dialog';
import { UsersComponent } from './../../../users/users/users.component';


import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';


@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.scss']
})
export class TopNavComponent implements OnInit {
  @Output() sideNavToggled = new EventEmitter<void>();
  
  constructor(private readonly router: Router, public userservice: UserService) {}
  userClaims: any;
  ngOnInit() {

    //this.userservice.getLoggedInUser().subscribe(user => {
     
     // this.userClaims = this.userservice.getLoggedInUser();
      

    //});

   this.userservice.getUserClaims().subscribe((data : any)=>{
    this.userClaims = data;///localStorage.getItem(`access_token`);
   // alert(this.userClaims)
    //console.log('claims',data);
   })
  }

  toggleSidebar() {
    
    this.sideNavToggled.emit();
  }

  onLoggedout() {
    localStorage.removeItem('isLoggedin');
    this.router.navigate(['/login']);
  }
  openUserList()
  {
    this.router.navigate(['/users']);
  }
  openPersonDialog(){
    // this.dialog.open(UsersComponent, {
    //   height: '400px',
    //   width: '600px',
    // });

    
 }


 
}
