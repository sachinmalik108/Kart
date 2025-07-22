import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { QuestionService } from '../shared/article.service';
import { CommentsService } from '../shared/comments.service'
import { Article, User, Comment } from '../shared/interface.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs'

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent implements OnInit, OnDestroy {

  title: string;
  description: string;
  commentservice :CommentsService;
  article:Article;
  curretUser: User;
  comments : Comment[];
  id:number;
  errors: Array<string> = [];

  subscription1: Subscription;

  constructor(
    private authservice: AuthService,
    private articleservice: QuestionService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit() {

    this.subscription1 = this.authservice.currentUser.subscribe(
      userData => {
        console.log(userData)
        if (userData === {}) {
          this.authservice.logout();
        }
        this.curretUser = userData;
      }
    )

    this.route.params.subscribe(
      (params: Params) => {
        if (params["id"]) {
          this.id = params["id"]
          this.articleservice.getSingleArticle(params["id"]).subscribe(
            data => {
              if (this.curretUser.EmailAddress == data["article"].UserEmailAddress) {
                console.log(data)
                this.title = data["article"].Title;
                this.description = data["article"].Description;
                
              } else {
                this.authservice.logout();
              }
            },
            err => {
              console.log(err)
              this.authservice.logout();
            }
          )
        }
      }
    )
  }

  createArticle(form: NgForm) {
    console.log(form.value)
    let payload = {
      Title: form.value.title,
      Description: form.value.description,
      UserEmailAddress:this.curretUser.EmailAddress,
      Id : this.id
      
    }
    console.log(payload)
   if(this.id){
     
    this.articleservice.updateArticle(payload,this.id).subscribe(
      article => {
        
        this.router.navigate(['/article/', this.id])
      },
      error => {
        this.errors = Object.keys(error.errors || {})
          .map(key => `${key} ${error.errors[key]}`)
      }
    )
   }else{
    this.articleservice.createArticle(payload).subscribe(
      article => {
        this.router.navigate([''])
      },
      error => {
        this.errors = Object.keys(error.errors || {})
          .map(key => `${key} ${error.errors[key]}`)
      }
    )
   }
  }
  deleteComment(comment: Comment) {
    console.log(comment.id)
    this.commentservice.destroyComment(comment.id)
      .subscribe(
        success => {
         
        },
        error => {
          console.log(error);
          this.authservice.logout()
        }
      );
  }


  ngOnDestroy() {
    this.subscription1.unsubscribe()
  }

}
