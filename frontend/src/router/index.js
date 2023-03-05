import Vue from 'vue'
import VueRouter from 'vue-router'
import { authGuard } from '@/auth/authGuard'

Vue.use(VueRouter)

/**
 * Used to route the various displays for the application.
 * Add in your additional views and add the appropriate auth guard in here
 * @type {[{path: string, component: (function(): Promise<{readonly default?: {name: string}}>), meta: {title: string}, name: string}, {path: string, component: (function(): Promise<{readonly default?: {name: string}}>), meta: {title: string}, name: string}]}
 */
const routes = [
  {
    path: '/',
    name: 'Home',
    beforeEnter: authGuard('/projects'),
    component: () => import('../views/AboutPage.vue'),
    meta: {
      title: 'Home Page'
    }
  },
  {
    path: '/login',
    beforeEnter: authGuard('/projects')
  },
  {
    path: '/people',
    name: 'Peoples Page',
    component: () => import('../views/PeoplesPage.vue'),
    beforeEnter: authGuard(),
    meta: {
      title: 'Peoples Page'
    }
  },
  {
    path: '/user:id',
    name: 'Profile Page',
    component: () => import('../views/ProfilePage.vue'),
    beforeEnter: authGuard(),
    meta: {
      title: 'Profile Page'
    }
  },
  {
    path: '/user:id/edit',
    name: 'EditUserPage',
    component: () => import('../views/EditUserPage.vue'),
    beforeEnter: authGuard(),
    meta: {
      title: 'Edit User Page'
    }
  },
  {
    path: '/people/:id',
    name: 'People Page',
    component: () => import('../views/PeoplePage.vue'),
    beforeEnter: authGuard(),
    meta: {
      title: 'People Page'
    }
  },
  {
    path: '/project',
    name: 'Projects Page',
    component: () => import('../views/ProjectsPage.vue'),
    beforeEnter: authGuard(),
    meta: {
      title: 'Projects Page'
    }
  },
  {
    path: '/project/:id',
    name: 'Project Page',
    component: () => import('../views/ProjectPage.vue'),
    beforeEnter: authGuard(),
    meta: {
      title: 'Project Page'
    }
  },
  {
    path: '/templates',
    component: () => import('../views/Templates.vue')
  },
  {
    path: '/resume/add',
    component: () => import('../views/AddUpdateResume.vue')
  },
  {
    path: '/resume/edit/:id',
    component: () => import('../views/AddUpdateResume.vue')
  },
  {
    path: '/resume/view/:id',
    component: () => import('../views/ViewReasume.vue')
  },
  {
    path: '/resume',
    component: () => import('../views/Layout.vue')
  },
  {
    path: '*',
    name: 'Page Not Found',
    component: () => import('../views/NotFoundPage.vue'),
    meta: {
      title: 'No Page found'
    }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
