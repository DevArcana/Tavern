import Category from "./Category";
import Role from "./Role";

export default interface Project {
  id: number;
  title: string;
  category: Category;
  roles: Role[];
  description: string;
  creationTimeStamp: string;
}