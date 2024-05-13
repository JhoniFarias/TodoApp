import { Component } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
    user : any;

    constructor(private angularFireAuth : AngularFireAuth){
      angularFireAuth.authState.subscribe(user => this.user = user?.displayName)
    }

    ngOnInit(){
    }
}
