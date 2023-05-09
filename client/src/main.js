import Vue from 'vue'
import VueRouter from 'vue-router'
import ElementUI from 'element-ui'
import locale from 'element-ui/lib/locale/lang/en'
import 'element-ui/lib/theme-chalk/index.css';
import App from './App.vue'
import routes from './routes';
import axios from 'axios';

Vue.config.productionTip = false
Vue.use(VueRouter)
Vue.use(ElementUI, { locale });
const router = new VueRouter({ routes });
axios.defaults.baseURL = process.env.VUE_APP_API_HOST;
Vue.prototype.$axios = axios;

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
