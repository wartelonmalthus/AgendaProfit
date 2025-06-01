<template>
  <div class="topo">
    <h2>Usuários</h2>
    <Button label="Adicionar" icon="pi pi-plus" @click="modalAberto = true" />
  </div>

  <TabelaGenerica :dados="usuarios" :colunas="colunas" @editar="editarUsuario" @excluir="excluirUsuario" />

 <ModalFormulario
    v-model:visivel="modalAberto"
    titulo="Novo Usuário"
    largura="500px"
    @salvar="salvarUsuario"
  >
    <div class="field mb-3">
      <label class="block mb-2">Nome</label>
      <InputText v-model="novoUsuario.nome" class="w-full" />
    </div>
    <div class="field mb-3">
      <label class="block mb-2">Senha</label>
      <InputText v-model="novoUsuario.senha" class="w-full" />
    </div>
    <div class="field mb-3">
      <label class="block mb-2">Email</label>
      <InputText v-model="novoUsuario.email" class="w-full" />
    </div>
    <div class="field mb-3">
      <label class="block mb-2">Telefone</label>
      <InputText v-model="novoUsuario.telefone" class="w-full" />
    </div>
     <div class="field mb-3">
      <label class="block mb-2">Descrição</label>
      <InputText v-model="novoUsuario.descricao" class="w-full" />
    </div>
    <div class="field mb-3">
      <label class="block mb-2">Agenda</label>
      <Dropdown
        v-model="novoUsuario.agendaId"
        :options="agendas"
        optionLabel="nome"
        optionValue="id"
        placeholder="Selecione uma agenda"
        class="w-full"
      />
    </div>
  </ModalFormulario>
</template>

<style scoped>
.topo {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 16px;
}

.field {
  margin-bottom: 1rem;
}
</style>

<script setup lang="ts">
import TabelaGenerica from '@/components/TabelaGenerica.vue'
import ModalFormulario from '@/components/ModalFormulario.vue'

import { agendaService } from '@/Services/AgendaService'
import { onMounted, ref, watch } from 'vue'
import Button from 'primevue/button'
import InputText from 'primevue/inputtext'
import Dropdown from 'primevue/dropdown'
import type { AgendaFiltro } from '@/Models/Agenda/AgendaFiltro'
import { usuarioService } from '@/Services/UsuarioService'
import type { UsuarioFiltro } from '@/Models/Usuarios/UsuarioFiltro'


const colunas = [
  { field: 'nome', header: 'Nome' },
  { field: 'email', header: 'Email'},
  { field: 'telefone', header: 'Telefone'},
  { field: 'descricao', header: 'Descricao'},
  { field: 'agendaId', header: 'AgendaId'}
]
const usuarios = ref<any[]>([])
const agendas = ref<any[]>([])
const filtros: UsuarioFiltro = {
  nome: '',
  telefone: '',
  email: '',
  numeroDaPagina: 1,
  tamanhoDaPagina: 10
}
const filtrosAgenda: AgendaFiltro = {
  nome: '',
  numeroDaPagina: 1,
  tamanhoDaPagina: 100
}


const modalAberto = ref(false)

const novoUsuario = ref<any>({
  id: null,
  nome: '',
  senha: null,
  email: '',
  telefone: '',
  descricao: '',
  agendaId: 0
})
watch(modalAberto, async (aberto) => {
  if (aberto) {
    agendas.value = await agendaService.listarAgendas(filtrosAgenda) 
  }
})

onMounted(async () => {
  await carregarUsuarios()
})
async function carregarUsuarios() {
  usuarios.value = await usuarioService.listarUsuarios(filtros)
}

async function salvarUsuario() {
    modalAberto.value = false
  if (novoUsuario.value.id) {
    await usuarioService.atualizarUsuario(novoUsuario.value)
  } else {
    await usuarioService.adicionarUsuario(novoUsuario.value)
  }
  await carregarUsuarios()
}

function editarUsuario(usuario: any) {
  modalAberto.value = true
  novoUsuario.value = { ...usuario } 
}

async function excluirUsuario(usuario: any) {
  await usuarioService.removerUsuario(usuario.id)
  await carregarUsuarios();
}
</script>