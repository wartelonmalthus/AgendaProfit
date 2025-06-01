import Aura from '@primeuix/themes/aura';
import PanelMenu from 'primevue/panelmenu'
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'


import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

import PrimeVue from 'primevue/config'
import 'primeicons/primeicons.css'
import 'primeflex/primeflex.css'
import Dropdown from 'primevue/dropdown'
import Button from 'primevue/button'

const app = createApp(App)

app.use(PrimeVue, {
    theme: {
        preset: Aura,
          options: {
            darkModeSelector: '.my-app-dark',
        }
    }
});
app.component('Button', Button)
app.component('PanelMenu', PanelMenu)
app.component('DataTable', DataTable)
app.component('Column', Column)


app.use(createPinia())
app.use(router)

app.mount('#app')
