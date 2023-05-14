import { Grid } from "semantic-ui-react";
import { Post } from "../../../app/models/Post";
import PostList from "./PostList";
import PostDetails from "../details/PostDetails";
import PostForm from "../form/PostForm";

interface Props {
    posts: Post[];
    selectedPost: Post | undefined;
    selectPost: (id: string) => void;
    cancelSelectPost: () => void;
    editMode: boolean;
    openForm: (id: string) => void;
    closeForm: () => void;
}

export default function PostDashboard({ posts, selectedPost, selectPost, cancelSelectPost, editMode, openForm, closeForm }: Props) {
    return (
        <Grid>
            <Grid.Column width="10">
                <PostList posts={posts} selectPost={selectPost} userId="TODO" />
            </Grid.Column>
            <Grid.Column width="6">
                {selectedPost &&
                    <PostDetails
                        post={selectedPost}
                        cancelSelectPost={cancelSelectPost}
                        openForm={openForm}
                    />}
                <PostForm
                    post={selectedPost}
                    closeForm={closeForm}
                />
            </Grid.Column>
        </Grid>
    );
}
