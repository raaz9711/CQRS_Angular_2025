import { Component, EventEmitter, inject, Input, input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { User, UserService } from '../user.service';

@Component({
  selector: 'app-add-user',
  imports: [ReactiveFormsModule],
  templateUrl: './add-user.html',
  styleUrl: './add-user.css'
})
export class AddUser  implements OnInit{
addEditUser! : FormGroup;

userService = inject(UserService)

@Input() user : User | null = null;
 constructor(private fb: FormBuilder) {}


@Output() saveForm = new EventEmitter<number>();

    //  <!-- public int Id { get; set; }
    // public required string Name { get; set; }
    // public required string Email { get; set; }
    // public bool IsActive { get; set; } = true;
    // public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    // public DateTime? UpdatedUtc { get; set; } -->

  ngOnInit(): void {
    if(this.user !== null ){
      this.addEditUser = this.fb.group({
      name: [this.user.name, [Validators.required, Validators.min(2)]],
      email: [this.user.email, [Validators.required, Validators.email]],
    });
    }
    else{
    // Using FormBuilder for cleaner syntax
    this.addEditUser = this.fb.group({
      name: ['', [Validators.required, Validators.min(2)]],
      email: ['', [Validators.required, Validators.email]],
    });
  }
  }

   onSubmit(): void {
    if (this.addEditUser.valid) {
      console.log(this.addEditUser.value);

      if(this.user == null)
      {
        this.userService.create({...this.addEditUser.value})
        .subscribe(
          {
            next : value => console.log(value),
            error : err => console.log(err),
            complete: () => {this.user = null; this.saveForm.emit(200) }

          }
        )
      }
      else if(this.user != null){
this.userService.update({...this.addEditUser.value,id:this.user.id,isActive : true})
        .subscribe(
          {
            next : value => console.log(value),
            error : err => console.log(err),
            complete: () => {this.user = null; this.saveForm.emit(201) }
          }
        )
      }

    } else {
      console.log('Form is invalid');
    }


  }

}
