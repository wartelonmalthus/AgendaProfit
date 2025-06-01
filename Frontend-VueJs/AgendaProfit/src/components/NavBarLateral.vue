<template>
  <aside class="sidebar">
    <PanelMenu :model="items" class="w-full mt-3" />
  </aside>
</template>

<script setup lang="ts">
import PanelMenu from 'primevue/panelmenu'
import { useRouter } from 'vue-router'

const router = useRouter()

const items = [
  {
    label: 'Contatos',
    icon: 'pi pi-user-plus',
    command: () => router.push('/contatos')
  },
  {
    label: 'Agendas',
    icon: 'pi pi-address-book',
    command: () => router.push('/agendas')
  },
   {
    label: 'Usuários',
    icon: 'pi pi-users',
    command: () => router.push('/usuarios')
  }
]
</script>

<style scoped>
.sidebar {
  flex: 0 0 20%;
  max-width: 20%;
  min-width: 200px;
  background-color: #00204b;
  color: white;
  padding: 16px;
  height: 100%;
  box-sizing: border-box;
  overflow-y: auto;
  overflow-x: hidden;
}

:deep(.p-panelmenu .p-menuitem-text),
:deep(.p-panelmenu .p-menuitem-icon) {
  color: white;
}
</style>
