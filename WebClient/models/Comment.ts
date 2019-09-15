export default interface Comment {
  id: number;
  content: string;
  projectId: number;
  children: Comment[];
}