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
        <!-- Mover a un slot segun entidad -->
        <v-card
          class="index-table-header"
          color="primary"
          dark
          flat
        >
          <v-card-text
            class="py-0"
          >
            <v-form>
              <v-row>
                <v-col cols="6">
                  <v-text-field
                    v-model="filter.codigo"
                    label="Código"
                    @keyup.enter="refresh()"
                  />
                </v-col>
                <v-col cols="6">
                  <v-text-field
                    v-model="filter.nombre"
                    label="Nombre"
                    @keyup.enter="refresh()"
                  />
                </v-col>
              </v-row>
            </v-form>
          </v-card-text>
          <v-card-actions
            class="pt-0"
          >
            <v-spacer></v-spacer>
            <v-btn
              depressed
              fab
              small
              color="primary"
              @click="refresh"
            >
              <v-icon dark>mdi-magnify</v-icon>
            </v-btn>
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
          </v-card-actions>

        </v-card>
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
        this.loading = true;
        let settings = this.options;
        settings.filters = this.filter;
        this.$store.dispatch(`${this.source}/loadPaginatedCollection`, settings)
        .then(() =>  {
          this.loading = false
        })
      }
    },
    computed: {
      filter() {
        return this.$store.getters[`${this.source}/filter`]
      },
      items() {
        return this.$store.getters[`${this.source}/entities`]
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