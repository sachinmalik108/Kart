
export interface User {
   
    EmailAddress?: string;
    Name?:string;
    Password?: string;
    
   ProfilePic?: string;
    
}

export interface Login{
    EmailAddress:string;
    Password :string;
}

export interface Article {
    id: number;
    title: string;
    description: string;
    createdAt: Date;
    updatedAt: Date;  
    UserEmailAddress: string;
}

export interface Comment {
    id: number;
   Ans : string;
   NetVotes:number;
   CreatedAt:Date;
   ModifiedAt:Date;
   UserEmailAddress:string;
   QuestionID:number;
  }
  export interface Vote{
      ID:number;
      IsVoted:boolean;
      IsUpvoted:boolean
      UserEmailAddress:string;
      AnswerID:number;
  }