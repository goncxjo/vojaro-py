<template>
    <EntidadIndexTabla
        :headers="headers"
        :source="source"
        nombreSingular="Universidad"
        nombrePlural="Universidades"
    ></EntidadIndexTabla>
</template>

<script>
  import store from '@/store'
  import router from '@/router'
  import { mapGetters } from 'vuex'
  import EntidadIndexTabla from '@/components/EntidadIndexTabla'

  export default {
    components: {
      EntidadIndexTabla
    },
    data() {
      return {
        source: 'universidades',
        headers: [
          { text: 'Acciones', value: 'actions', sortable: false },
          { text: 'Codigo', value: 'codigo' },
          { text: 'Nombre', value: 'nombre' },
        ],
        errors: []
      }
    }
  }
</script>

<style lang="sass">
  header.index-table-header
    border-radius: 3px 3px 0px 0px 
</style>