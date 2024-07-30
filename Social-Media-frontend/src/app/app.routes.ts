// app.routes.ts
import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PostComponent } from './post/post.component';
import { UserEngagementComponent } from './user-engagement/user-engagement.component';
import { UserFeedComponent } from './user-feed/user-feed.component';

export const routes: Routes = [
    { path: '', component: UserFeedComponent },
    { path: 'posts', component: PostComponent },
    { path: 'engagement', component: UserEngagementComponent },
];
