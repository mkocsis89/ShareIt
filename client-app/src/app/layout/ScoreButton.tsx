import { useCallback } from "react";
import { Button, Image, Label } from "semantic-ui-react";

interface Props {
    score: number;
    postId: string;
    like: (postId: string) => void;
    type: "creativity" | "uniqueness";
}

export default function ScoreButton(props: Props) {
    const src = props.type === "creativity"
        ? "/assets/bulb.png"
        : "/assets/fingerprint.png";

    const onLikeClick = useCallback(() => {
        props.like(props.postId);
    }, [props]);

    return (
        <Button as="div" labelPosition="right">
            <Button onClick={onLikeClick} icon>
                <Image src={src} style={{ width: "15px", height: "15px" }} />
            </Button>
            <Label as="a" basic>
                {props.score}
            </Label>
        </Button>
    );
}
