import About from "../pages/about";
import Login from "../pages/auth/Login";
import Contact from "../pages/contact/Index";
import Dashboard from "../pages/dashboard/Index";
import Home from "../pages/home/Index";

const routes = [
    { path: '/', component: Home, roleRequired: ['AllowAnonymous', 'User'], private: false },
    { path: '/about', component: About, roleRequired: ['AllowAnonymous', 'User'], private: false },
    { path: '/contact', component: Contact, roleRequired: ['AllowAnonymous', 'User'], private: false },
    { path: '/login', component: Login, roleRequired: ['AllowAnonymous', 'User'], private: false },
    { path: '/dashboard', component: Dashboard, roleRequired: ['Admin'], private: true },
];
export { routes };