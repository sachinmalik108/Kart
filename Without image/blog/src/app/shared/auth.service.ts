import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './interface.service';
import { BehaviorSubject, ReplaySubject, Observable, throwError } from 'rxjs'
import { map, distinctUntilChanged, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
 

  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());

  private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();



  constructor(
    private http: HttpClient,
    private router: Router
  ){}
  
  register(user)  {
    console.log(user)
    return this.http.post
      ("http://localhost:56506/api/User/Add",user)
      .pipe(
        catchError(err => {
          return throwError(err.error)
        }),
        map(data => {
          console.log(data);
          this.setAuth(data["user"])
          
          return data;
        })
      )
      
  }

  login(login) :Observable<User> {
    console.log(login.EmailAddress)
    return this.http.post
      ("http://localhost:56506/api/Users/Login",login
      )
      .pipe(
        map(data => {
           
            
           
          return data;
        })
      )
  }

  getUser() {
    this.http.get("http://localhost:56506/api/Users", this.addHeader())
      .subscribe(
        (response) => {
          console.log(response);
          this.setAuth(response["user"])
        },
        (error) => {
          console.log(error);
          this.logout();
        }
      )

  }

  addHeader() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Token ' + localStorage.getItem("jwt")
      })
    };
    return httpOptions;
  }

  checkAuth() {
    console.log(localStorage.getItem("jwt"))
    if (localStorage.getItem("jwt")) {
      this.getUser();
    } else {
      this.logout();
    }
  }

  setAuth(user: User) {
    this.currentUserSubject.next(user);
    this.isAuthenticatedSubject.next(true);
    console.log("authset")
    
  }

  logout() {
    console.log("logout")
    this.currentUserSubject.next({} as User);
    this.isAuthenticatedSubject.next(false);
    // localStorage.removeItem("jwt");
    this.router.navigate([''])
  }
}



