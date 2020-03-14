<template>
  <v-data-table
    :headers="headers"
    :items="universidades"
    :items-per-page="5"
    class="elevation-1"
  ></v-data-table>
</template>

<script>
  import { API } from '../backend'

  export default {
    data() {
      return {
        headers: [
          { text: 'Codigo', value: 'codigo' },
          { text: 'Nombre', value: 'nombre' },
        ],
        universidades: [],
        errors: []
      }
    },
    created() {
      API.get('universidades')
      .then(response => {
        this.universidades = response.data
      })
      .catch(e => {
        this.errors.push(e)
      })
    }
  }
</script>