import React from 'react';
import { Label, ListGroupItem, ListGroup, Container } from 'reactstrap';
import './Histogram.css';

export type Bigram = {
    words: string;
    count: number;
}

const Header = (props: { text: string }) => (
    <Label className="label">{props.text}</Label>
);

const BigramItem = (props: { words: string, count: number }) => {
    const text = `"${props.words}": ${props.count}`;

    return (
        <ListGroupItem
            className="bigram"
            title={text}>{text}
        </ListGroupItem>);
};

const BigramList = (props: { bigrams: Bigram[] }) => {
    return (
        props.bigrams.length > 0 ?
        <ListGroup className="bigram-list">
                {props.bigrams.map((bigram) => (
                    <BigramItem key={bigram.words} words={bigram.words} count={bigram.count} />
            ))}
        </ListGroup> :
        <NoBigramsMessage />
    );
};

const NoBigramsMessage = () => (
    <div>
        There are no bigrams within the provided text.
    </div>
);

const Histogram = (props: { isLoading: boolean, bigrams: Bigram[] | undefined }) => {
    return (
        <Container className="histogram">
            <Header text="Bigram Histogram"></Header>
            {props.isLoading && <div><i className={"fa fa-circle-o-notch fa-spin"}></i>Parsing Text...</div>}
            {!props.isLoading && props.bigrams && <BigramList bigrams={props.bigrams!} />}
        </Container>);
};
    
export default Histogram;