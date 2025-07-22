import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../shared/auth.service';
import { User ,Login} from '../shared/interface.service';
import { Router } from '@angular/router';
import { BehaviorSubject, ReplaySubject, Observable, throwError } from 'rxjs'
import { map, distinctUntilChanged, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  user:any=null;
  errors: Array<string> = [];
  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());

  private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();
  constructor(
    private authservice: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  
  OnSignIn(form: NgForm){
    console.log(form.value)
    let login: Login = {
      EmailAddress: form.value.email,
      Password: form.value.password
    }
    
    this.authservice.login(login).subscribe(
      (response) => {
        this.router.navigate([''])
        this.user = response
       if( response.EmailAddress!=null)  {
       this.authservice.setAuth(this.user)
      }
        
      
      
      }
      
    )

  }

}
