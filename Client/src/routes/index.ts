import About from "../pages/about";
import Contact from "../pages/contact/Index";
import Home from "../pages/home/Index";

const routes = [
    { path: '/', component: Home, roleRequired: 'user' },
    { path: '/about', component: About, roleRequired: 'user' },
    { path: '/contact', component: Contact, roleRequired: 'user' },
];
export {routes};