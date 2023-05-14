import { useCallback, useEffect, useState } from "react";
import axios from "axios";
import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import { Post } from "../models/Post";
import PostDashboard from "../../features/posts/dashboard/PostDashboard";

function App() {
    const [posts, setPosts] = useState<Post[]>([]);
    const [selectedPost, setSelectedPost] = useState<Post | undefined>(undefined);
    const [editMode, setEditMode] = useState(false);

    useEffect(() => {
        axios.get<Post[]>("http://localhost:5000/api/posts/").then((response) => {
            setPosts(response.data);
        });
    }, []); // [] only fire ones

    const handleSelectedPost = useCallback((id: string) => {
        setSelectedPost(posts.find(post => post.id === id))
    }, [])

    const handleCancelSelectPost = useCallback(() => {
        setSelectedPost(undefined);
    }, [])

    function handleFormOpen(id?: string) {
        id ? handleSelectedPost(id) : handleCancelSelectPost();
        setEditMode(true);
    }

    function handleFormClose() {
        setEditMode(false);
    }

    return (
        <>
            <NavBar openForm={handleFormOpen} />
            <Container style={{ marginTop: '7em' }}>
                <PostDashboard
                    posts={posts}
                    selectedPost={selectedPost}
                    selectPost={handleSelectedPost}
                    cancelSelectPost={handleCancelSelectPost}
                    editMode={editMode}
                    openForm={handleFormOpen}
                    closeForm={handleFormClose}
                />
            </Container>
        </>
    );
}

export default App;
