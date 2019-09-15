import Category from "./Category";
import Role from "./Role";

export default interface Project {
  id: number;
  title: string;
  category: Category;
  functions: Role[];
  description: string;
  creationTimeStamp: string;
}