// comment.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Comment } from '../models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private apiUrl = 'http://localhost:5182/Comment';

  constructor(private http: HttpClient) {}

  addComment(comment: Comment): Observable<Comment> {
    return this.http.post<Comment>(this.apiUrl, comment);
  }
  getCommentsForPosts(postIds: number[]): Observable<Comment[]> {
    return this.http.get<Comment[]>(`${this.apiUrl}?postIds=${postIds.join(',')}`);
  }
}
