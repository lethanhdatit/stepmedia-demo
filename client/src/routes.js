import ListOrder from './components/ListOrder'
import NewOrder from './components/NewOrder'
import NotFound from './components/NotFound'
import ListCustomer from './components/ListCustomer'
import ListShop from './components/ListShop'
import ListProduct from './components/ListProduct'
import NewProduct from './components/NewProduct'
import NewShop from './components/NewShop'
import NewCustomer from './components/NewCustomer'


const routes = [
    { path: '/', component: ListOrder },
    { path: '/orders', component: ListOrder },
    { path: '/new-order', component: NewOrder },
    { path: '/customers', component: ListCustomer },
    { path: '/new-customer', component: NewCustomer },
    { path: '/shops', component: ListShop },
    { path: '/new-shop', component: NewShop },
    { path: '/products', component: ListProduct },
    { path: '/new-product', component: NewProduct },
    { path: "*", component: NotFound }
];

export default routes;