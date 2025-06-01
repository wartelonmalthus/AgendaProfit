import type { AgendaFiltro } from '@/Models/Agenda/AgendaFiltro'
import http from './http'
import type { AgendaCreateRequest } from '@/Models/Agenda/AgendaCreateRequest'

export const agendaService = {
 async listarAgendas(filtro: AgendaFiltro) {
    const response = await http.get('/api/Agenda', { params: filtro })
    return response.data
  },

  async adicionarAgenda(agenda: AgendaCreateRequest) {
      const response = await http.post('/api/Agenda', agenda)
      return response.data

  },
  async removerAgenda(id: number){
     const response =  await http.delete(`/api/Agenda/${id}`)
     return response.data
  },
     
  async atualizarAgenda(agenda: any){
    const response = await http.put('/api/Agenda', agenda)
    return response.data
    }
}