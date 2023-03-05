import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from '@/router'
import { Auth0Plugin } from '@/auth'
import authConfig from '../auth_config.json'
import JsonTreeViewer from 'vue-json-tree-viewer'
import store from './store' // Third-party
import Print from 'vue-print-nb'
import VeeValidate from 'vee-validate'
// Plugins
import HTMLControlsPlugin from './plugins/HTMLControls.plugin'
import TemplatePlugin from './plugins/Template.plugin'
import HelpersPlugin from './plugins/Helpers.plugin'
import './plugins/VeeValidation.plugin'

Vue.config.productionTip = false

Vue.use(Auth0Plugin, {
  domain: authConfig.domain,
  clientId: authConfig.clientId,
  onRedirectCallback: (appState) => {
    router.push(
      appState && appState.targetUrl
        ? appState.targetUrl
        : window.location.pathname
    )
  }
})
Vue.config.productionTip = false
Vue.use(HTMLControlsPlugin)
Vue.use(TemplatePlugin)
Vue.use(HelpersPlugin)
Vue.use(VeeValidate)
Vue.use(Print)

Vue.use(JsonTreeViewer)

new Vue({
  router,
  vuetify,
  store,
  render: (h) => h(App)
}).$mount('#app')
