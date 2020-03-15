<template>
  <div>
    <UniversidadIndexPanelBusqueda />
    <br />
    <UniversidadIndexTabla />
  </div>
</template>

<script>
  import UniversidadIndexPanelBusqueda from '@/components/UniversidadIndexPanelBusqueda'
  import UniversidadIndexTabla from '@/components/UniversidadIndexTabla'

  export default {
    components: {
      UniversidadIndexPanelBusqueda,
      UniversidadIndexTabla,
    },
  }
</script>
