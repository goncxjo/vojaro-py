<template>
  <v-card>
    <v-data-table
      :headers="headers"
      :items="universidades"
      :items-per-page="5"
    >
      <template v-slot:top>
        <v-toolbar
          class="index-table-header"
          color="primary"
          dark
          flat
        >
          <v-toolbar-title>Universidades</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-btn
            class="mx-2"
            depressed
            fab
            small
            color="primary"
            @click="refresh"
          >
            <v-icon dark>mdi-refresh</v-icon>
          </v-btn>
          <v-btn
            class="mx-2"
            depressed
            fab
            dark
            small
            color="primary"
            @click="create"
          >
            <v-icon dark>mdi-plus</v-icon>
          </v-btn>
        </v-toolbar>
      </template>
    
      <template v-slot:item.actions="{ item }">
        <v-btn
          class="mx-2"
          depressed
          fab
          dark
          x-small
          color="success"
          @click="edit(item)"
        >
          <v-icon dark>mdi-pencil</v-icon>
        </v-btn>
        <v-btn
          class="mx-2"
          depressed
          fab
          dark
          x-small
          color="error"
          @click="erase(item)"
        >
          <v-icon dark>mdi-delete</v-icon>
        </v-btn>
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
          { text: 'Acciones', value: 'actions', sortable: false },
          { text: 'Codigo', value: 'codigo' },
          { text: 'Nombre', value: 'nombre' },
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
      refresh() {
        this.$store.dispatch(`universidades/loadCollection`)
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

<style lang="sass">
  header.index-table-header
    border-radius: 3px 3px 0px 0px 
</style>