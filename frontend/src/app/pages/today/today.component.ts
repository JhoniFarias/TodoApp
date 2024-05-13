import { Component } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { AngularFireAuth } from '@angular/fire/compat/auth';

@Component({
  selector: 'app-today',
  templateUrl: './today.component.html',
  styleUrl: './today.component.scss'
})
export class TodayComponent {

    public todos: any[] | undefined;

    constructor(
      private angularFireAuth: AngularFireAuth,
      private todoService: TodoService) {}
 
 
    ngOnInit(){
       this.getAllToday();
    }
 
    getAllToday(){
     return this.angularFireAuth.idToken.subscribe(token => {
         this.todoService.getAllToday(token).subscribe((todos:any) => this.todos = todos)
     })
    }

    setStateTask(todo:any){
      this.angularFireAuth.idToken.subscribe(token => {
        this.todoService.markAsDone(token, todo.id).subscribe(response => {
          this.getAllToday();
        });
       
      });
    }
}
