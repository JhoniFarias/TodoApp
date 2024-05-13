import { Component } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { AngularFireAuth } from '@angular/fire/compat/auth';

@Component({
  selector: 'app-all',
  templateUrl: './all.component.html',
  styleUrl: './all.component.scss'
})
export class AllComponent {

  public todos: any[] | undefined;

  constructor(private angularFireAuth: AngularFireAuth, private todoService: TodoService) { }


  ngOnInit() {
    this.getAll();
  }

  getAll() {
    return this.angularFireAuth.idToken.subscribe(token => {
      this.todoService.getAll(token).subscribe((todos: any) => this.todos = todos)
    })
  }

  setStateTask(todo: any) {
    this.angularFireAuth.idToken.subscribe(token => {
      this.todoService.markAsDone(token, todo.id).subscribe(response => {
        this.getAll();
      });

    })

  
  }
}
