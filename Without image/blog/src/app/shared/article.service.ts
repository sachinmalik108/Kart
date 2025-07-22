import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { RequestOptions } from '@angular/http';
import { Article } from './interface.service';
import { BehaviorSubject, ReplaySubject, Observable, throwError } from 'rxjs'
import { map, distinctUntilChanged, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {


  constructor(
    private http: HttpClient,
  ) { }

  getArticles(filters?) {
    const params = filters;
    console.log("loa")
    return this.http.get("http://localhost:56506/api/dashboard")
      .pipe(
        catchError(err => {
          return throwError(err.error)
        })
      )
  }

 

  getSingleArticle(id: number) {
    return this.http.get("http://localhost:56506/Question/GetDetails/" + id)
      .pipe(
        catchError(err => {
          return throwError(err.error)
        }),
        map(
          (data) => {
            console.log
            return data;
          }
        )
      )
  }

  createArticle(payload) {
    console.log(payload)
    return this.http.post("http://localhost:56506/api/Question/Add",payload)
      .pipe(
        catchError(err => {
          console.log(err)
          return throwError(err.error)
        }),
        map(
          (data) => {
            console.log(data)
            return data['article'];
          }
        )
      )
  }

  updateArticle(payload,id) {
    return this.http.put("http://localhost:56506/Question/Put/" + id,
               payload
      ,
      )
      .pipe(
        catchError(err => {
          return throwError(err.error)
        }),
        map(
          (data) => {
            return data['article'];
          }
        )
      )
  }

  deleteArticle(id: number) {
    return this.http.delete("http://localhost:56506/Question/Delete/" + id,
    )
  }

 
}
