<template>
  <div class="topo">
    <h2>Agendas</h2>
    <Button label="Adicionar" icon="pi pi-plus" @click="modalAberto = true" />
  </div>

  <TabelaGenerica :dados="agendas" :colunas="colunas" @editar="editarAgenda" @excluir="excluirAgenda" />

 <ModalFormulario
    v-model:visivel="modalAberto"
    titulo="Nova Agenda"
    largura="400px"
    @salvar="salvarAgenda"
  >
    <div class="field mb-3">
      <label class="block mb-2">Nome</label>
      <InputText v-model="novaAgenda.nome" class="w-full" />
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
import { onMounted, ref } from 'vue'
import Button from 'primevue/button'
import InputText from 'primevue/inputtext'
import type { AgendaFiltro } from '@/Models/Agenda/AgendaFiltro'


const colunas = [
  { field: 'id', header: 'Id' },
  { field: 'nome', header: 'Nome'},
  { field: 'totalDeContatos', header: 'TotalDeContatos'}
]
const agendas = ref<any[]>([])
const filtros: AgendaFiltro = {
  nome: '',
  numeroDaPagina: 1,
  tamanhoDaPagina: 10
}

const modalAberto = ref(false)

const novaAgenda = ref<any>({
    id: null,
    nome: ''
})
onMounted(async () => {
  await carregarAgendas()
})
async function carregarAgendas() {
  agendas.value = await agendaService.listarAgendas(filtros)
}

async function salvarAgenda() {
   modalAberto.value = false
  if (novaAgenda.value.id) {
    await agendaService.atualizarAgenda(novaAgenda.value)
  } else {
    await agendaService.adicionarAgenda(novaAgenda.value)
  }
  await carregarAgendas()

}

function editarAgenda(agenda: any) {
  modalAberto.value = true
  novaAgenda.value = { ...agenda } 
}

async function excluirAgenda(agenda: any){
  await agendaService.removerAgenda(agenda.id);
  await carregarAgendas();
}
</script>