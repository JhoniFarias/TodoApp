import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  constructor(private httpClient: HttpClient) { }

  createTodo(todo: any ,token: any) {
    this.httpClient.post(`${environment.apiUrl}/api/todo`, todo,{ headers: this.composeHttpHeader(token) }).subscribe();
  }

  markAsDone(token: any, todoId : any){
    return this.httpClient.post(`${environment.apiUrl}/api/todo/markAsDone`, { id: todoId },{ headers: this.composeHttpHeader(token) });
  }

  getAllToday(token: any) {
    return this.httpClient.get(`${environment.apiUrl}/api/todo/today`, { headers: this.composeHttpHeader(token) });
  }
  getAllTomorrow(token: any) {
    return this.httpClient.get(`${environment.apiUrl}/api/todo/tomorrow`, { headers: this.composeHttpHeader(token) });
  }
  getAll(token: any) {
    return this.httpClient.get(`${environment.apiUrl}/api/todo/getAll`, { headers: this.composeHttpHeader(token) });
  }

  composeHttpHeader(token : any): HttpHeaders{
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

}
