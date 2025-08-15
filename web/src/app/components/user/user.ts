import { Component, inject, OnInit } from '@angular/core';
import { User, UserService } from './user.service';
import { DatePipe } from '@angular/common';
import { AddUser } from './add-user/add-user';

@Component({
  selector: 'app-user',
  imports: [DatePipe,AddUser],
  templateUrl: './user.html',
  styleUrl: './user.css'
})
export class UserComponent implements OnInit {

user : User | null = null

rows : User[] = [];
search = '';
page = 1;
pageSize = 10;
loading = false;



api  = inject(UserService)

onAddEdit(id:number = 0){
  this.isAddEdit = true;
  if(id == 0){
    this.user = null;
  }
  else {
  this.user = this.rows.filter(e => e.id == id)[0];
  }
}

onDelete(id:number){
this.api.delete(id)
.subscribe({
  next : value => console.log(value),
  error : err => console.log(err),
  complete: () => {console.log('delete complete') ; this.load()}
})
}




isAddEdit = false;
  ngOnInit(): void {
    this.load();
  }

 showTable(event : number){
  this.load();
  this.isAddEdit = !event
 }
  
  load(){
this.loading = true;
    this.api.list({ search: this.search, page: this.page, pageSize: this.pageSize })
      .subscribe({
        next: (data) => { this.rows = data; this.loading = false; },
        error: (err) => { this.loading = false; }
      });

  }

}
