import { Button, Form, Segment } from "semantic-ui-react";
import { Post } from "../../../app/models/Post";

interface Props {
    post: Post | undefined;
    closeForm: () => void;
}

export default function PostForm({ post, closeForm }: Props) {
    const options = [
        { value: "frog", text: "Frog" },
        { value: "shield", text: "Shield" },
        { value: "star", text: "Star" },
    ];

    return (
        <Segment clearing>
            <Form>
                <Form.Input placeholder='Title'></Form.Input>
                <Form.TextArea placeholder='Description'></Form.TextArea>
                <Form.Dropdown
                    placeholder='Special parts'
                    fluid
                    multiple
                    search
                    selection
                    options={options}
                />
                <Button floated='right' positive type='submit' content='Submit' />
                <Button floated='right' type="button" content='Cancel' />
            </Form>
        </Segment >
    )
}