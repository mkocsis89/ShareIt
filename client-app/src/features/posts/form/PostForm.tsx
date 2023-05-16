import { Button, DropdownProps, Form, Segment } from "semantic-ui-react";
import { Post } from "../../../app/models/Post";
import { Part } from "../../../app/models/Part";
import { ChangeEvent, SyntheticEvent, useState } from "react";

interface Props {
    selectedPost: Post | undefined;
    closeForm: () => void;
    createOrEditPost: (post: Post) => void;
}

export default function PostForm({ selectedPost, closeForm, createOrEditPost }: Props) {
    const options = [
        { value: "Frog", text: "Frog" },
        { value: "Shield", text: "Shield" },
        { value: "Star", text: "Star" },
        { value: "Diamond", text: "Diamond" }
    ];

    const initialState: Post = selectedPost ?? {
        id: "",
        title: "",
        date: "2023-05-15", // TODO
        description: "",
        specialParts: [],
        scores: []
    };

    const [post, setPost] = useState<Post>(initialState);

    function handleSubmit() {
        createOrEditPost(post);
        console.log(post);
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setPost({ ...post, [name]: value });
    }

    function handleDropdownChange(event: SyntheticEvent<HTMLElement, Event>, data: DropdownProps) {
        const { name, value } = data;
        
        const parts = (value as []).map(partName => ({
            postId: post.id,
            name: partName
        } as Part));

        setPost({ ...post, [name]: parts });
    }

    return (
        <Segment clearing>
            <Form onSubmit={handleSubmit} autoComplete="off">
                <Form.Input placeholder="Title" value={post.title} name="title" onChange={handleInputChange} />
                <Form.TextArea placeholder="Description" value={post.description} name="description" onChange={handleInputChange} />
                <Form.Input type="date" placeholder="Date" value={post.date} name="date" onChange={handleInputChange} />
                <Form.Dropdown
                    placeholder='Special parts'
                    fluid
                    multiple
                    search
                    selection
                    options={options}
                    value={post.specialParts.map(part => part.name)}
                    name="specialParts"
                    onChange={handleDropdownChange}
                />
                <Button floated='right' positive type='submit' content='Submit' />
                <Button onClick={closeForm} floated='right' type="button" content='Cancel' />
            </Form>
        </Segment >
    )
}