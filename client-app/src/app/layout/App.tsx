import { useEffect, useState } from "react";
import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import { Post } from "../models/Post";
import PostDashboard from "../../features/posts/dashboard/PostDashboard";
import { v4 as uuid } from "uuid";
import agent from "../api/agent";

function App() {
    const [posts, setPosts] = useState<Post[]>([]);
    const [selectedPost, setSelectedPost] = useState<Post | undefined>(undefined);
    const [editMode, setEditMode] = useState(false);

    useEffect(() => {
        agent.Posts.list().then((response) => {
            // temporary solution
            let posts: Post[] = [];
            response.forEach(post => {
                post.date = post.date.split("T")[0];
                posts.push(post);
            })
            setPosts(response);
        });
    }, []); // [] only fire ones

    function handleSelectPost(id: string) {
        setSelectedPost(posts.find(post => post.id === id))
    }

    function handleCancelSelectPost() {
        setSelectedPost(undefined);
    }

    function handleFormOpen(id?: string) {
        id ? handleSelectPost(id) : handleCancelSelectPost();
        setEditMode(true);
    }

    function handleFormClose() {
        setEditMode(false);
    }

    function handleCreateOrEditPost(post: Post) {
        if (post.id) {
            agent.Posts.update(post).then(() => {
                setPosts([...posts.filter(p => p.id !== post.id), post])
                setSelectedPost(post);
                setEditMode(false);
            })
        }
        else {
            post.id = uuid();
            post.specialParts?.forEach(part => part.postId = post.id);
            agent.Posts.create(post).then(() => {
                setPosts([...posts, post]);
                setSelectedPost(post);
                setEditMode(false);
            });
        }
    }

    function handleDeletePost(id: string) {
        agent.Posts.delete(id).then(() => {
            setPosts([...posts.filter(post => post.id !== id)]);
        });
    }

    return (
        <>
            <NavBar openForm={handleFormOpen} />
            <Container style={{ marginTop: '7em' }}>
                <PostDashboard
                    posts={posts}
                    selectedPost={selectedPost}
                    selectPost={handleSelectPost}
                    cancelSelectPost={handleCancelSelectPost}
                    editMode={editMode}
                    openForm={handleFormOpen}
                    closeForm={handleFormClose}
                    createOrEditPost={handleCreateOrEditPost}
                    deletePost={handleDeletePost}
                />
            </Container>
        </>
    );
}

export default App;
