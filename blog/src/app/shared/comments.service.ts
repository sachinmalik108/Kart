import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Comment } from './interface.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  addComment(ID, payload) {
console.log(payload)
    return this.http.post
      ("http://localhost:56506/api/Answer/add/" + ID ,
      
        payload
      ,
      )
      .pipe(map(data => data["comment"]));
  }

  getAllComments(ID) {
    console.log("got here")
    return this.http.get("http://localhost:56506/api/Answer/Get/" + ID );
      
  }

  destroyComment(ID) {
    return this.http
      .delete("http://localhost:56506/Answer/Delete/"  + ID
      );
  }

AddVote(payload){
  console.log(payload)
  return this.http.post("http://localhost:56506/api/Vote/LikeVote" 
  ,payload);
}
DeleteVote(payload){
  console.log(payload)
  return this.http.post("http://localhost:56506/api/Vote/DislikeVote" 
  ,payload);
}

  
}
