import { Component } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { GoogleAuthProvider } from 'firebase/auth';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
   
  constructor(private angularFireAuth : AngularFireAuth){

  }

  login(){
    this.angularFireAuth
      .signInWithPopup(new GoogleAuthProvider())
  }
}
