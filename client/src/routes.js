import ListOrder from './components/ListOrder.vue'
import NotFound from './components/NotFound'

const routes = [
    { path: '/', component: ListOrder },
    { path: '/orders', component: ListOrder },
    { path: "*", component: NotFound }
];

export default routes;