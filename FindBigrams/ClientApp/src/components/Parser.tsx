import React, { useState } from 'react';
import { Label, Container } from 'reactstrap';

import './Parser.css';

const Header = (props: { text: string }) => (
    <Label className="label">{props.text}</Label>
);

const InputText = (props: { value: string, onChange: (e: React.ChangeEvent<HTMLTextAreaElement>) => void }) => (
    <div>
        <textarea placeholder="Enter text here..."
            className="textarea"
            onChange={props.onChange}
            value={props.value}>
        </textarea>
    </div>
);

const FindBigrams = (props: { text: string, onClick: () => void }) => (
    <button className="find-bigrams button" onClick={props.onClick}>
        {props.text}
    </button>
);

const ResetButton = (props: { text: string, onClick: () => void }) => (
    <button className="button" onClick={props.onClick}>
        {props.text}
    </button>
);

const Parser = (props: { onFindBigrams: (text: string) => void, onReset: () => void }) => {
    const [text, setText] = useState("");

    const handleFindBigramsClick = () => {
        props.onFindBigrams(text);
    }

    const handleResetClick = () => {
        setText("");
        props.onReset();
    }

    const handleChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
        setText(e.target.value);
    }

    return (
        <Container className="parser">
            <Header text="Text to Parse"></Header>
            <InputText value={text} onChange={handleChange} />
            <Container className="button-container">
                <FindBigrams
                    text="Find Bigrams"
                    onClick={handleFindBigramsClick} />
                <ResetButton
                    text="Reset"
                    onClick={handleResetClick} />
            </Container>
        </Container>
    );
};

export default Parser;