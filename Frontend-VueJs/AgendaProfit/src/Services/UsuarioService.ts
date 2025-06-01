import type { UsuarioFiltro } from "@/Models/Usuarios/UsuarioFiltro"
import http from "./http"
import type { CreateUsuarioRequest } from "@/Models/Usuarios/CreateUsuarioRequest"

export const usuarioService = {

  async listarUsuarios(filtro: UsuarioFiltro) {
    const response = await http.get('/api/Usuario', { params: filtro })
    return response.data
   },
  async adicionarUsuario(usuario: CreateUsuarioRequest) {
        const response = await http.post('/api/Usuario', usuario)
        return response.data
    },

  async removerUsuario(id: number) {
        const response = await http.delete(`/api/Usuario/${id}`)
        return response.data
    },
    
   async atualizarUsuario(usuario: any){
        const response = await http.put('/api/Usuario', usuario)
        return response.data
    }
}
