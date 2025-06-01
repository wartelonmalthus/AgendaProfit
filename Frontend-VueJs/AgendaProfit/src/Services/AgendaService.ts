import type { AgendaFiltro } from '@/Models/Agenda/AgendaFiltro'
import http from './http'
import type { AgendaCreateRequest } from '@/Models/Agenda/AgendaCreateRequest'

export const agendaService = {
 async listarAgendas(filtro: AgendaFiltro) {
    const response = await http.get('/api/Agenda', { params: filtro })
    return response.data
  },

  async adicionarAgenda(agenda: AgendaCreateRequest) {
      await http.post('/api/Agenda', agenda)
  },

  async removerAgenda(id: number){
    await http.delete(`/api/Agenda/${id}`)
  },
     
  async atualizarAgenda(agenda: any){
    const response = await http.put('/api/Agenda', agenda)
    return response.data
    }
}