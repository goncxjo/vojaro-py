<template>
    <EntidadIndexTabla
        :headers="headers"
        :items="universidades"
        source="universidades"
    ></EntidadIndexTabla>
</template>

<script>
  import store from '@/store'
  import router from '@/router'
  import { mapGetters } from 'vuex'
  import EntidadIndexTabla from '@/components/EntidadIndexTabla'

  export default {
    data() {
      return {
        headers: [
          { text: 'Acciones', value: 'actions', sortable: false },
          { text: 'Codigo', value: 'codigo' },
          { text: 'Nombre', value: 'nombre' },
        ],
        errors: []
      }
    },
    computed: {
      ...mapGetters('universidades', {
        universidades: 'filteredCollection'
      })
    },
    created() {
      this.$store.dispatch(`universidades/loadCollection`)
    },
  }
</script>