import { Component, OnInit } from '@angular/core';
import { UserService, UserEngagement } from '../services/user.service';

@Component({
  selector: 'app-user-engagement',
  templateUrl: './user-engagement.component.html',
  styleUrls: ['./user-engagement.component.css']
})
export class UserEngagementComponent implements OnInit {
  userEngagementScores: UserEngagement[] = [];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUserEngagementScores().subscribe(
      (scores: UserEngagement[]) => {
        this.userEngagementScores = scores;
      },
      (error) => {
        console.error('Error fetching user engagement scores', error);
      }
    );
  }
}
