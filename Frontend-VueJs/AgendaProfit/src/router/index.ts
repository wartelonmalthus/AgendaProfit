import { createRouter, createWebHistory } from 'vue-router'
import Contatos from '../views/Contatos.vue'
import Agendas from '../views/Agenda.vue'
import Usuarios from '../views/Agenda.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/contatos',
      name: 'contato',
      component: Contatos,
    },
    {
      path: '/agendas',
      name: 'agenda',
      component: Agendas,
    },
    {
      path: '/usuarios',
      name: 'usuario',
      component: Usuarios,
    },
    
  ],
})

export default router
