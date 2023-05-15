import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Post } from "../../../app/models/Post";
import ScoreButton from "../../../app/layout/ScoreButton";
import { useCallback, useState } from "react";
import { Score } from "../../../app/models/Score";

interface Props {
    posts: Post[];
    selectPost: (id: string) => void;
    deletePost: (id: string) => void;
    userId: string; // TODO
}

export default function PostList({ posts, selectPost, deletePost, userId }: Props) {
    const [postScores, setPostScores] = useState<{ [postId: string]: Score[] }>({});

    const likeCreativity = useCallback((postId: string) => {
        const post = posts.find((post) => post.id === postId);
        if (post /*&& !postScores[postId]?.some((score) => score.userId === props.userId*/) {
            const updatedScores = [
                ...(postScores[postId] || []),
                {
                    id: "",
                    postId: postId,
                    userId: userId,
                    type: 0,
                },
            ];
            setPostScores((prevScores) => ({
                ...prevScores,
                [postId]: updatedScores,
            }));
        }
    }, [userId, posts, postScores]);

    const likeUniqueness = useCallback((postId: string) => {
        const post = posts.find((post) => post.id === postId);
        if (post /*&& !postScores[postId]?.some((score) => score.userId === props.userId*/) {
            const updatedScores = [
                ...(postScores[postId] || []),
                {
                    id: "",
                    postId: postId,
                    userId: userId,
                    type: 1,
                },
            ];
            setPostScores((prevScores) => ({
                ...prevScores,
                [postId]: updatedScores,
            }));
        }
    }, [userId, posts, postScores]);

    return (
        <Segment>
            <Item.Group divided>
                {posts.map((post) => (
                    <Item key={post.id}>
                        <Item.Content>
                            <Item.Header as="a">{post.title}</Item.Header>
                            <Item.Meta>{post.date}</Item.Meta>
                            <Item.Description>
                                <div>{post.description}</div>
                            </Item.Description>
                            <Item.Extra>
                                {post.specialParts.map((part, index) => (
                                    <Label key={index}>{part.name}</Label>
                                ))}
                                <div>
                                    <ScoreButton
                                        score={postScores[post.id]?.filter((score) => score.type === 0)?.length || 0}
                                        postId={post.id}
                                        like={likeCreativity}
                                        type="creativity"
                                    />
                                    <ScoreButton
                                        score={postScores[post.id]?.filter((score) => score.type === 1)?.length || 0}
                                        postId={post.id}
                                        like={likeUniqueness}
                                        type="uniqueness"
                                    />
                                    <Button onClick={() => selectPost(post.id)} floated="right" content="View" color="blue" />
                                    <Button onClick={() => deletePost(post.id)} floated="right" content="Delete" color="red" />
                                </div>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    );
}