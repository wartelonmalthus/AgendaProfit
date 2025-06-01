export interface CreateContatoRequest {
  nome: string
  email: string
  telefone: string
  descricao?: string
  agendaId: number
}