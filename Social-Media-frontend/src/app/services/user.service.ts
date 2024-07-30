import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User, UserEngagement } from '../models/user';  // Ensure correct import

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private selectedUserSubject: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(null);
  selectedUser$: Observable<User | null> = this.selectedUserSubject.asObservable();

  private apiUrl = 'http://localhost:5182/User'; // API endpoint for users
  private engagementUrl = 'http://localhost:5182/User/engagement-scores'; // API endpoint for engagement scores

  constructor(private http: HttpClient) {}

  setSelectedUser(user: User): void {
    this.selectedUserSubject.next(user);
  }

  getSelectedUser(): User | null {
    return this.selectedUserSubject.value;
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }

  getFirstUser(): Observable<User> {
    return this.getUsers().pipe(
      map((users: User[]) => users[0])
    );
  }

  getUserEngagementScores(): Observable<UserEngagement[]> {
    return this.http.get<UserEngagement[]>(this.engagementUrl);
  }
}
export { UserEngagement };

