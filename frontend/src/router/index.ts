// Vue imports
import Vue from 'vue'
import Router from 'vue-router'

// 3rd party imports
import Auth from '@okta/okta-vue'

// our own imports
import Hello from '@/components/Hello.vue';
import RunRecords from '@/components/RunRecords.vue'

Vue.use(Auth, {
  issuer: 'https://dev-60116582.okta.com/oauth2/default',
  client_id: '0oa4duru0hSI7mNlB5d7/aln4duwlwgJrRvWcx5d7',
  redirect_uri: 'http://localhost:8080/implicit/callback',
  scope: 'openid profile email'
})

Vue.use(Router)

let router = new Router({
  mode: 'history',
  routes: [
	{
  	path: '/',
  	name: 'Hello',
  	component: Hello
	},
	{
  	path: '/implicit/callback',
  	component: Auth.handleCallback()
	},
  {
    path: '/run-records',
    name: 'RunRecords',
    component: RunRecords,
    meta: {
      requiresAuth: true
    }
  },
  ]
})

router.beforeEach(Vue.prototype.$auth.authRedirectGuard())

export default router