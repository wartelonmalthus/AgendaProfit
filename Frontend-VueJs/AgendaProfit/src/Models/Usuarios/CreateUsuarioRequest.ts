export interface CreateUsuarioRequest {
  nome: string
  senha:string
  email: string
  telefone: string
  descricao?: string
  agendaId: number
}