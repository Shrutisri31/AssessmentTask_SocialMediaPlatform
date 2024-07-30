import { Comment } from './comment';

export interface Post {
  postID: number;
  userID: number;
  content: string;
  comments?: Comment[];
}
  