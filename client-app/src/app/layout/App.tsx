import { useEffect, useState } from "react";
import axios from "axios";
import { List } from "semantic-ui-react";
import NavBar from "./NavBar";
import { Post } from "../models/Post";

function App() {
  const [posts, setPosts] = useState<Post[]>([]);

  useEffect(() => {
    axios.get<Post[]>("http://localhost:5000/api/posts/").then((response) => {
      setPosts(response.data);
    });
  }, []); // [] only fire ones

  return (
    <div>
      <NavBar />
      <List>
        {posts.map((post) => (
          <List.Item key={post.id}>{post.title}</List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
