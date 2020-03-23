<template>
  <v-card>
    <v-data-table
      :headers="headers"
      :items="items"
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
    props: ['source', 'headers', 'nombreSingular', 'nombrePlural'],
    methods: {
      create() {
        router.push({ name: `${this.source}.new`})
      },
      edit(item) {
        router.push({ name: `${this.source}.edit`, params: { id: item.id } })
      },
      erase(item) {
        var answer = confirm('¿Desea eliminar este registro?')
        if (answer == true) {
          this.$store.dispatch(`${this.source}/delete`, item.id)
        }
      },
      refresh() {
        this.$store.dispatch(`${this.source}/loadCollection`)
      }
    },
    computed: {
      items() {
        return this.$store.getters[`${this.source}/filteredCollection`]
      }
    },
    created() {
      this.$store.dispatch(`${this.source}/loadCollection`)
    },
  }
</script>

<style lang="sass">
  header.index-table-header
    border-radius: 3px 3px 0px 0px 
</style>