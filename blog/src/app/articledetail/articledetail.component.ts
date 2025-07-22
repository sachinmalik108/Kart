import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { QuestionService } from '../shared/article.service'
import { CommentsService } from '../shared/comments.service'
import { Article, Comment, User,Vote } from '../shared/interface.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-articledetail',
  templateUrl: './articledetail.component.html',
  styleUrls: ['./articledetail.component.css']
})
export class ArticledetailComponent implements OnInit {

  isAuthenticated: Boolean = false;
  article: any = null;
  comments: any=[];
  vote:any=null;
  currentUser: User;

  constructor(
    private authservice: AuthService,
    private articleservice: QuestionService,
    private commentservice: CommentsService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.authservice.isAuthenticated.subscribe(
      (bool) => {
        this.isAuthenticated = bool;
      }
    );
    this.authservice.currentUser.subscribe(
      (userData) => {
        this.currentUser = userData;
      }
    );

    this.route.params.subscribe(
      (params: Params) => {
        this.articleservice.getSingleArticle(params["id"]).subscribe(
          data => {
            this.article = data
            console.log(this.article);
            
            
            this.populateAnswers();
          },
          err =>console.log(err)
        )
      }
    )
    }
    populateAnswers() {
      console.log("got it")
      this.commentservice.getAllComments(this.article.ID)
      
        .subscribe(comments => {
        this.comments = comments;
          
          console.log(this.comments)
          
        });

    }
    deleteAnswer(id: number) {
      console.log(id)
      this.commentservice.destroyComment(id)
        .subscribe(
          success => {
            this.populateAnswers();
          },
          error => {
            console.log(error);
            this.authservice.logout()
          }
        );
       
    }
    AddVote(id :number){
      console.log(id)
      let payload={
        
        IsVoted:true,
        IsUpvoted:true,
        UserEmailAddress:this.currentUser.EmailAddress,
        AnswerID:id
      }
      
      this.commentservice.AddVote(payload).subscribe();
      this.populateAnswers();
    }

    DeleteVote(id :number){
      console.log(id)
      let payload={
        
        IsVoted:true,
        IsUpvoted:false,
        UserEmailAddress:this.currentUser.EmailAddress,
        AnswerID:id
      }
      this.populateAnswers();
      this.commentservice.DeleteVote(payload).subscribe();
      
    }


    addComment(form: NgForm) {
    console.log(form.value)
      let payload={
        Ans:form.value.comment,
        NetVotes :0,
        UserEmailAddress:"sachinmalik@gmail.com",
        QuestionID:this.article.ID

      }
      
      this.commentservice
        .addComment(this.article.ID, payload)
        .subscribe(
          comment => {
            this.populateAnswers();
            this.comments.unshift(comment);
          },
          errors => {
            console.log(errors)
            this.authservice.logout()
          }
        );
        
      form.reset();
    }
    deleteArticle(id: number){
      this.articleservice.deleteArticle(id).subscribe(
        success => this.router.navigate(['']),
        error => this.authservice.logout()
      )
    }
}
  
  

