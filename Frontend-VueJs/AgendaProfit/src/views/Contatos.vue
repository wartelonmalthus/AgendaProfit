<template>
  <div class="topo">
    <h2>Contatos</h2>
    <Button label="Adicionar" icon="pi pi-plus" @click="modalAberto = true" />
  </div>

  <TabelaGenerica :dados="contatos" :colunas="colunas" @editar="editarContato" @excluir="excluirContato" />

 <ModalFormulario
    v-model:visivel="modalAberto"
    titulo="Novo Contato"
    largura="500px"
    @salvar="salvarContato"
  >
    <div class="field mb-3">
      <label class="block mb-2">Nome</label>
      <InputText v-model="novoContato.nome" class="w-full" />
    </div>
    <div class="field mb-3">
      <label class="block mb-2">Email</label>
      <InputText v-model="novoContato.email" class="w-full" />
    </div>
    <div class="field mb-3">
      <label class="block mb-2">Telefone</label>
      <InputText v-model="novoContato.telefone" class="w-full" />
    </div>
     <div class="field mb-3">
      <label class="block mb-2">Descrição</label>
      <InputText v-model="novoContato.descricao" class="w-full" />
    </div>
    <div class="field mb-3">
      <label class="block mb-2">Agenda</label>
      <Dropdown
        v-model="novoContato.agendaId"
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

import type { ContatoFiltro } from '@/Models/Contatos/ContatoFiltro'
import { contatoService } from '@/Services/ContatoService'
import { agendaService } from '@/Services/AgendaService'
import { onMounted, ref, watch } from 'vue'
import Button from 'primevue/button'
import InputText from 'primevue/inputtext'
import Dropdown from 'primevue/dropdown'
import type { AgendaFiltro } from '@/Models/Agenda/AgendaFiltro'
import type { CreateContatoRequest } from '@/Models/Contatos/CreateContatoRequest'


const colunas = [
  { field: 'nome', header: 'Nome' },
  { field: 'email', header: 'Email'},
  { field: 'telefone', header: 'Telefone'},
  { field: 'descricao', header: 'Descricao'},
  { field: 'agendaId', header: 'AgendaId'}
]
const contatos = ref<any[]>([])
const agendas = ref<any[]>([])
const filtros: ContatoFiltro = {
  nome: '',
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

const novoContato = ref<any>({
  id: null,
  nome: '',
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
  await carregarContatos()
})
async function carregarContatos() {
  contatos.value = await contatoService.listarContatos(filtros)
}

async function salvarContato() {
    modalAberto.value = false
  if (novoContato.value.id) {
    await contatoService.atualizarContato(novoContato.value)
  } else {
    await contatoService.adicionarContato(novoContato.value)
  }
  await carregarContatos()
}

function editarContato(contato: any) {
  modalAberto.value = true
  novoContato.value = { ...contato } 
}

async function excluirContato(contato: any) {

  await contatoService.removerContato(contato.id)
  await carregarContatos();

}
</script>