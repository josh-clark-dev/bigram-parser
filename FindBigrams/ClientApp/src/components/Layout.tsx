import * as React from 'react';

const Layout = (props: { children?: React.ReactNode }) => (
    <div className="layout">
        {props.children}
    </div>
);

export default Layout;