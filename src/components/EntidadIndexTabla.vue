<template>
  <v-card>
    <v-data-table
      :headers="headers"
      :items="items"
      :options.sync="options"
      :server-items-length="total"
      :loading="loading"
      :search="search"
    >
      <template #top>
        <v-toolbar
          class="index-table-header"
          color="primary"
          dark
          flat
        >
          <v-text-field
            v-model="search"
            append-icon="mdi-magnify"
            label="Search"
            single-line
            hide-details
            class="mr-4"
          ></v-text-field>
          <v-btn
            depressed
            fab
            small
            color="primary"
            @click="refresh"
          >
            <v-icon dark>mdi-refresh</v-icon>
          </v-btn>
          <v-btn
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
    
      <template #item.actions="{ item }">
        <v-btn
          class="mx-2"
          depressed
          fab
          dark
          x-small
          color="info"
          @click="view(item)"
        >
          <v-icon dark>mdi-magnify</v-icon>
        </v-btn>
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
      <template #no-data>
        Sin datos
      </template>
      <template #loading>
        Cargando...
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
    data() {
      return {
        search: '',
        loading: true,
        options: {},
      }
    },
    watch: {
      options: {
        handler() {
          this.refresh()
        }
      },
      deep: true
    },
    methods: {
      create() {
        router.push({ name: `${this.source}.new`})
      },
      view(item) {
        router.push({ name: `${this.source}.view`, params: { id: item.id } })
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
        this.loading = true
        this.$store.dispatch(`${this.source}/loadPaginatedCollection`, this.options)
        .then(() =>  {
          this.loading = false
        })
      }
    },
    computed: {
      items() {
        return this.$store.getters[`${this.source}/filteredCollection`]
      },
      total() {
        return this.$store.getters[`${this.source}/totalEntities`]
      }
    },
    mounted() {
      this.refresh()
    },
  }
</script>

<style lang="sass">
  header.index-table-header
    border-radius: 3px 3px 0px 0px 
</style>