import React, { useState } from 'react';
import Histogram, { Bigram } from './Histogram';
import Parser from './Parser';
import Switch from 'react-switch';

import './Home.css';

type ApplicationProps = {
    Bigrams: Bigram[]
}

const WelcomeMessage = () => (
    <div className="welcome-message">
        Use this page to generate a histogram of bigrams contained with a block of text. Copy your text into the text area below and click the 'Find Bigrams' button. A histogram of the bigrams contained within the text will display to the right.
    </div>
);

const DarkModeToggle = (props: { checked: boolean, onChange: () => void }) => (
    <label>
        <span className="switch-label">Dark Mode</span>
        <Switch
            checked={props.checked}
            onChange={props.onChange}
            onColor="#FFF"
            onHandleColor="#3A82F7"
            handleDiameter={22}
            uncheckedIcon={false}
            checkedIcon={false}
            activeBoxShadow="0px 0px 1px 3px rgba(0,0,0, 0.2)"
            height={15}
            width={48}
        />
    </label>
);
        
const post = async (url: string, data: any) => {
    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': "application/json"
        },
        body: JSON.stringify(data)
    }).catch((err) => { console.error(err); });

    if (response && response.ok)
      return await response.json();
    
    return Promise.reject(response);  
};

const Home = () => {
    const [histogram, setHistogram] = useState<Bigram[]>();
    const [darkMode, setDarkMode] = useState(false);
    const [isLoading, setIsLoading] = useState(false);

    const handleFindBigrams = async (text: string) => {
        setIsLoading(true);

        var histogram = await post('/api/histogram', { text: text });

        setIsLoading(false);

        setHistogram(histogram);
    };

    const handleReset = () => {
        setHistogram(undefined);
    };

    const handleDarkModeChange = () => {
        setDarkMode(!darkMode);
    };

    return (
        <div className={"home " + (darkMode ? "dark-mode" : "light-mode")}>
            <WelcomeMessage />
            <div className="toggle-container">
                <DarkModeToggle checked={darkMode} onChange={handleDarkModeChange} />
            </div>
            <div>
                <div className="sections">
                    <Parser onFindBigrams={handleFindBigrams} onReset={handleReset} />
                    <Histogram isLoading={isLoading} bigrams={histogram} />
                </div>
            </div>
        </div>
    );
}

export default Home;
