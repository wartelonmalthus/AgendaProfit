<template>
  <DataTable :value="dados" :paginator="true" :rows="10" responsiveLayout="scroll">
    <Column v-for="col in colunas" :key="col.field" :field="col.field" :header="col.header" />
    <Column header="Ações">
      <template #body="slotProps">
        <Button icon="pi pi-pencil" rounded variant="outlined"  @click="emit('editar', slotProps.data)" />
        <Button icon="pi pi-trash"  rounded variant="outlined"  class="p-button-danger" @click="emit('excluir', slotProps.data)" />
      </template>
    </Column>
  </DataTable>
</template>

<script setup lang="ts">
import { defineProps, defineEmits } from 'vue'
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import Button from 'primevue/button'

const props = defineProps<{
  dados: any[],
  colunas: { field: string, header: string }[]
}>()
const emit = defineEmits(['editar', 'excluir'])
</script>