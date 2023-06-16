export interface IPayLoadPrivateRoute {
    Components: React.FC<any>;
    requiredRoles: string[];
    auth: boolean,
    roleCheck: string,
    path: string
}