<template>
  <Dialog
    :header="titulo"
    v-model:visible="modelVisivel"
    :modal="true"
    :style="{ width: largura }"
  >
    <slot />
    <div class="text-right mt-4">
      <Button label="Fechar" icon="pi pi-times" @click="fechar" class="p-button-text" />
      <Button label="Salvar" icon="pi pi-check" @click="$emit('salvar')" />
    </div>
  </Dialog>
</template>

<script setup lang="ts">
import Dialog from 'primevue/dialog'
import Button from 'primevue/button'
import { computed } from 'vue'

const props = defineProps<{
  titulo: string
  visivel: boolean
  largura?: string
}>()

const emit = defineEmits(['update:visivel', 'salvar'])

const modelVisivel = computed({
  get: () => props.visivel,
  set: (value) => emit('update:visivel', value)
})

function fechar() {
  emit('update:visivel', false)
}
</script>