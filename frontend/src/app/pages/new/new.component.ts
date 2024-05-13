import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { TodoService } from '../../services/todo.service';
import { AngularFireAuth } from '@angular/fire/compat/auth';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrl: './new.component.scss'
})
export class NewComponent {
  public form: FormGroup = new FormGroup({
    title: new FormControl(''),
    date: new FormControl(new Date().toLocaleDateString())
  });

  constructor(
    private formBuilder: FormBuilder,
    private todoService: TodoService,
    private angularFireAuth: AngularFireAuth) {
  }

  submitForm() {
    this.angularFireAuth.idToken.subscribe(token => {
      this.todoService.createTodo(this.form.value, token);
    });
  }
}
