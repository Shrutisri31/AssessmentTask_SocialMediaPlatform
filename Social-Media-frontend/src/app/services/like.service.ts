// like.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Like } from '../models/like';

@Injectable({
  providedIn: 'root'
})
export class LikeService {
  private apiUrl = 'http://localhost:5182/api/Like';

  constructor(private http: HttpClient) {}

  likePost(like: Like): Observable<void> {
    return this.http.post<void>(this.apiUrl, like);
  }
}
