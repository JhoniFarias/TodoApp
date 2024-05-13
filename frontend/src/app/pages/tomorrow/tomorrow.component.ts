import { Component } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { TodoService } from '../../services/todo.service';

@Component({
  selector: 'app-tomorrow',
  templateUrl: './tomorrow.component.html',
  styleUrl: './tomorrow.component.scss'
})
export class TomorrowComponent {

  public todos: any[] | undefined;

  constructor(
    private angularFireAuth: AngularFireAuth,
    private todoService: TodoService) { }


  ngOnInit() {
    this.getAllTomorrow();
  }

  getAllTomorrow() {
    return this.angularFireAuth.idToken.subscribe(token => {
      this.todoService.getAllTomorrow(token).subscribe((todos: any) => this.todos = todos)
    })
  }

  setStateTask(todo: any) {
    this.angularFireAuth.idToken.subscribe(token => {
      this.todoService.markAsDone(token, todo.id).subscribe(responde => {
        this.getAllTomorrow();
      });
    })

   
  }
}
