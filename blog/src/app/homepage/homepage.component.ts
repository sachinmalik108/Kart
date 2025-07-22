import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { QuestionService } from '../shared/article.service'
import { Article } from '../shared/interface.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  isAuthenticated: Boolean = false;
  articles : any = [];
  feeds: Array<Article> = [];
  loading:Boolean = true;

  constructor(
    private authservice: AuthService,
    private articleservice: QuestionService,
    private router: Router
  ) { }

  ngOnInit() {
    this.authservice.isAuthenticated.subscribe(
      (bool) => {
        this.isAuthenticated = bool;
        if(bool){
         
        }
      }
    );

      this.getArticles();
  }

  getArticles() {
    console.log("lol")
    this.articleservice.getArticles({limit:20}).subscribe(
      (data) => {
        console.log(data)
        this.articles = data;
        
        this.loading = false;
      },
      (err) => {
        console.log(err.error)
      }
    )
  }

  

  fetchArticle(id:number){
    this.articleservice.getSingleArticle(id).subscribe(
      (data) => {
        this.router.navigate(['/article/',id]);
      },
      (err) => {
        console.log(err.error)
      }
    )
  }
}
