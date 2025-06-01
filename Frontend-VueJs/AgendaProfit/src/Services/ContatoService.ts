import type { ContatoFiltro } from '@/Models/Contatos/ContatoFiltro'
import http from './http'
import type { CreateContatoRequest } from '@/Models/Contatos/CreateContatoRequest'

export const contatoService = {
    async listarContatos(filtro: ContatoFiltro) {
        const response = await http.get('/api/Contato', { params: filtro })
        return response.data
    },

    async adicionarContato(contato: CreateContatoRequest) {
        const response = await http.post('/api/Contato', contato)
        return response.data
    },

    async removerContato(id: number) {
        const response = await http.delete(`/api/Contato/${id}`)
        return response.data
    },
    
    async atualizarContato(contato: any){
        const response = await http.put('/api/Contato', contato)
        return response.data
    }
}