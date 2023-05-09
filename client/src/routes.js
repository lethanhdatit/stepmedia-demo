import ListOrder from './components/ListOrder.vue'
import NewOrder from './components/NewOrder.vue'
import NotFound from './components/NotFound'

const routes = [
    { path: '/', component: ListOrder },
    { path: '/orders', component: ListOrder },
    { path: '/new-order', component: NewOrder },
    { path: "*", component: NotFound }
];

export default routes;