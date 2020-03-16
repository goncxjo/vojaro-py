<template>
<v-card>
  <v-data-table
      :headers="headers"
      :items="universidades"
      :items-per-page="5"
    >
      <template v-slot:top>
        <v-toolbar
          color="primary"
          dark
          dense
          flat
        >
          <v-toolbar-title>Universidades</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-btn
            text
            @click="crearItem"
          >
            Crear
          </v-btn>
        </v-toolbar>
      </template>
    
      <template v-slot:item.actions="{ item }">
        <v-icon
          small
          class="mr-2"
          @click="editarItem(item)"
        >
          mdi-pencil
        </v-icon>
        <v-icon
          small
          @click="borrarItem(item)"
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
      crearItem (item) {
        router.push({ name: 'universidades.crear'})
      },
      editarItem (item) {
        router.push({ name: 'universidades.editar', params: { id: item.id } })
      },
      borrarItem (item) {
        const index = this.universidades.indexOf(item)
        confirm('¿Desea eliminar esta universidad?') && this.universidades.splice(index, 1)
      },
    },
    computed: {
      ...mapGetters('universidades', {
        universidades: 'entidadesFiltradas'
      })
    },
    created() {
      this.$store.dispatch(`universidades/cargarLista`)
    },
  }
</script>