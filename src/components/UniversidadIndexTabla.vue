<template>
<v-card>
  <v-data-table
      :headers="headers"
      :items="universidades"
      :items-per-page="5"
    >
      <template v-slot:top>
        <v-toolbar
          dense
          flat
        >
          <v-toolbar-title class="primary--text">Universidades</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-btn
            text
            @click="create"
          >
            Crear
          </v-btn>
        </v-toolbar>
      </template>
    
      <template v-slot:item.actions="{ item }">
        <v-icon
          small
          class="mr-2"
          @click="edit(item)"
        >
          mdi-pencil
        </v-icon>
        <v-icon
          small
          @click="erase(item)"
        >
          mdi-delete
        </v-icon>
      </template>
      <template v-slot:no-data>
        <v-alert type="warning">
          No hay datos
        </v-alert>
      </template>
    </v-data-table>
  </v-card>
</template>

<script>
  import store from '@/store'
  import router from '@/router'
  import { mapGetters } from 'vuex'

  export default {
    data() {
      return {
        headers: [
          { text: 'Codigo', value: 'codigo' },
          { text: 'Nombre', value: 'nombre' },
          { text: 'Acciones', value: 'actions', sortable: false },
        ],
        errors: []
      }
    },
    methods: {
      create() {
        router.push({ name: 'universidades.new'})
      },
      edit(item) {
        router.push({ name: 'universidades.edit', params: { id: item.id } })
      },
      erase(item) {
        var answer = confirm('¿Desea eliminar esta universidad?')
        if (answer == true) {
          this.$store.dispatch('universidades/delete', item.id)
        }
      },
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