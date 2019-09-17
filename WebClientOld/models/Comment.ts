import User from "./User";

export default interface Comment {
  id: number;
  content: string;
  projectId: number;
  creator: User;
  children: Comment[];
}