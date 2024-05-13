import { Component } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent {

  constructor(
    private angularFireAuth : AngularFireAuth, 
    private route: Router) {
    
  }

  ngOnInit(){
      this.angularFireAuth.onAuthStateChanged(data => {
          if(data){
            this.route.navigateByUrl('/today')
          }else{
            this.route.navigateByUrl('/login')
          }
      })
 
  }
}
