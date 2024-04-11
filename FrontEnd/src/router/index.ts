import { createRouter, createWebHistory } from 'vue-router'
import IndexView from '../views/Computers/IndexView.vue'
import CreateView from '../views/Computers/CreateView.vue'
import EditView from '../views/Computers/EditView.vue'
import LoginView from '../views/Auth/LoginView.vue'
import useStore from '@/stores'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'index',
      component: IndexView
    },
    {
      path: '/computers/create',
      name: 'create',
      component: CreateView,
      beforeEnter: (to, from) => {
        const { auth } = useStore();
        if (!auth.isAuthenticated && from.name !== 'login')
          return {name: 'login'};
      }
    },
    {
      path: '/computers/edit/:id',
      name: 'edit',
      component: EditView,
      beforeEnter: (to, from) => {
        const { auth } = useStore();
        if (!auth.isAuthenticated && from.name !== 'login')
          return {name: 'login'};
      }
    },
    {
      path: '/auth/login',
      name: 'login',
      component: LoginView
    },
    {
      path: '/:pathMatch(.*)*',
      name: 'NotFound',
      component: () => import('@/views/Error/404.vue')
    },
  ]
})


export default router
