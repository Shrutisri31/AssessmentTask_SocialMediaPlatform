import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PostService } from '../services/post.service';
import { UserService } from '../services/user.service';
import { LikeService } from '../services/like.service';
import { CommentService } from '../services/comment.service';
import { Post } from '../models/post';
import { User } from '../models/user';
import { Comment } from '../models/comment';
import { Like } from '../models/like';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-user-feed',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-feed.component.html',
  styleUrls: ['./user-feed.component.css']
})
export class UserFeedComponent implements OnInit {
  posts: Post[] = [];
  users: User[] = [];
  newComment: string = '';
  errorMessage: string | null = null;
  bannedWords: string[] = ["monolith", "spaghettiCode", "goto", "hack", "architrixs", "quickAndDirty", "cowboy", "yo", "globalVariable", "recursiveHell", "backdoor", "hotfix", "leakyAbstraction", "mockup", "singleton", "silverBullet", "technicalDebt"];
  selectedUser: User | null = null;
  highlightedPostId: number | null = null;
  commentEditPostId: number | null = null;

  constructor(
    private postService: PostService,
    private userService: UserService,
    private likeService: LikeService,
    private commentService: CommentService
  ) {}

  ngOnInit(): void {
    this.userService.selectedUser$.subscribe(user => this.selectedUser = user);
    this.loadPosts();
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getUsers().subscribe(users => {
      this.users = users;
    });
  }

  loadPosts(): void {
    this.postService.getPosts().pipe(
      switchMap(posts => {
        this.posts = posts;
        // Extract post IDs and fetch comments
        const postIds = posts.map(post => post.postID);
        return this.commentService.getCommentsForPosts(postIds);
      })
    ).subscribe(comments => {
      this.posts.forEach(post => {
        post.comments = comments.filter(comment => comment.postID === post.postID);
      });
    });
  }

  getUserById(userId: number): User | undefined {
    return this.users.find(user => user.userID === userId);
  }

  likePost(post: Post): void {
    this.highlightedPostId = post.postID;
    if (this.selectedUser) {
      const like: Like = {
        likeID: 0,
        userID: this.selectedUser.userID,
        postID: post.postID
      };
      this.likeService.likePost(like).subscribe(() => {
        this.loadPosts();
        this.highlightedPostId = post.postID; // Highlight the post
      });
    }
  }

  toggleCommentSection(post: Post): void {
    this.commentEditPostId = this.commentEditPostId === post.postID ? null : post.postID;
  }

  addComment(post: Post): void {

    if (this.newComment.trim() === '') {
      alert('Please input a text.');
      return;
    }

    if (this.bannedWords.some(word => this.newComment.includes(word))) {
      alert('Comment contains inappropriate words.')
      return;
    }
    if (this.selectedUser) {
      const comment: Comment = {
        commentID: 0,
        userID: this.selectedUser.userID,
        postID: post.postID,
        content: this.newComment
      };
      this.commentService.addComment(comment).subscribe(() => {
        this.loadPosts();
        this.newComment = '';
        this.errorMessage = null;
        this.commentEditPostId = null; // Hide the comment section after adding
      });
    }
  }

  isPostLiked(post: Post): boolean {
    return this.highlightedPostId === post.postID;
  }
}
