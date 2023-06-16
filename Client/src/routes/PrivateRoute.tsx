import React from 'react';
import { Navigate, Route, RouteProps } from 'react-router-dom';

interface PrivateRouteProps extends RouteProps {
    isAuthenticated: boolean;
    redirectTo: string;
    path: string,
    element: any
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({
    isAuthenticated,
    redirectTo,
    path,
    element,
    ...routeProps
}) => {
    if (!isAuthenticated) {
        return <Navigate to={redirectTo} replace />;
    }

    return <Route children={element} path={path} {...routeProps} />;
};

export default PrivateRoute;