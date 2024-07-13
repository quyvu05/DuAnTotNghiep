import { setupLayouts } from 'virtual:generated-layouts'
import { createRouter, createWebHistory } from 'vue-router'
import routes from '~pages'
import { canNavigate } from './utils'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/account-settings',
      redirect: () => ({ name: 'account-settings-tab', params: { tab: 'account' } }),
    },
    ...setupLayouts(routes),
  ],
})

router.beforeEach(to => {
  if(!canNavigate(to)) {
    return { name: 'login' }
  }
})


// Docs: https://router.vuejs.org/guide/advanced/navigation-guards.html#global-before-guards
export default router
