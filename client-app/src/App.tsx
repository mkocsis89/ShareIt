import { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from "axios";
import { Header, List } from "semantic-ui-react";

function App() {
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5000/api/post/").then((response) => {
      setPosts(response.data);
    });
  }, []); // [] only fire ones

  return (
    <div>
      <Header as="h2" icon="users" content="Share It" />
      <img src={logo} className="App-logo" alt="logo" />
      <List>
        {posts.map((post: any) => (
          <List.Item key={post.id}>{post.title}</List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
