import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../shared/auth.service'
import { User } from '../shared/interface.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  
  errors: Array<string> = [];

  constructor(
    private authservice: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  OnSignUp(form: NgForm){
    console.log(form)
    let user: User = {
     
      EmailAddress: form.value.email,
      Password: form.value.password,
      // ProfilePic : form.value.image,
      
      Name : form.value.name

    }
    console.log(user.EmailAddress)
    
    this.authservice.register(user).subscribe(
      (response) => {
        this.router.navigate([''])
      },
      (error) => {
        console.log(error)
        console.log(Object.keys(error.errors || {})
        .map(key => `${key} ${error.errors[key]}`));

        this.errors = Object.keys(error.errors || {})
        .map(key => `${key} ${error.errors[key]}`)
      }
    )
  }

}
