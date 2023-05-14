import { Part } from "./Part"
import { Score } from "./Score"

export interface Post {
    id: string;
    title: string;
    date: string;
    description: string;
    specialParts: Part[];
    scores: Score[];
}