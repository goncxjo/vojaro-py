<template>
  <v-card
    outlined
  >
    <v-data-table
      :headers="headers"
      :items="items"
      :items-per-page="5"
      :search="search"
      hide-default-footer
    >
      <template v-slot:top>
        <v-toolbar
          class="index-table-header"
          dense
          flat
        >
          <v-toolbar-title>Departamentos</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialog" max-width="500px">
            <template v-slot:activator="{ on }">
              <v-btn
                fab
                icon
                small
                color="primary"
                v-on="on"
              >
                <v-icon v-show="!readonly" dark>mdi-plus</v-icon>
              </v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">{{ formTitle }}</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col>
                      <v-text-field v-model="editedItem.nombre" label="Nombre departamento"></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="close">Cancelar</v-btn>
                <v-btn color="blue darken-1" text @click="save">Guardar</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>
    
      <template v-slot:item.actions="{ item }">
        <v-btn
          class="mx-2"
          depressed
          fab
          dark
          x-small
          color="info"
          v-show="readonly"
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
          v-show="!readonly"
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
          v-show="!readonly"
          @click="erase(item)"
        >
          <v-icon dark>mdi-delete</v-icon>
        </v-btn>
      </template>
      <template v-slot:no-data>
        Sin datos
      </template>
    </v-data-table>
  </v-card>
</template>

<script>
  import store from '@/store'
  import router from '@/router'
  import { mapGetters } from 'vuex'

  export default {
    props: ['items', 'readonly'],
    data() {
      return {
        dialog: false,
        search: '',
        headers: [
          { text: 'Acciones', value: 'actions', sortable: false },
          { text: 'Nombre', value: 'nombre' },
        ],
        editedIndex: -1,
        editedItem: {
          nombre: ''
        },
        defaultItem: {
          nombre: ''
        }
      }
    },
    methods: {
      edit(item) {
        this.editedIndex = this.items.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialog = true
      },
      erase(item) {
        const index = this.items.indexOf(item)
        confirm('Are you sure you want to delete this item?') && this.items.splice(index, 1)
      },
      close() {
        this.dialog = false
        setTimeout(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        }, 300)
      },
      save() {
        if (this.editedIndex > -1) {
          Object.assign(this.items[this.editedIndex], this.editedItem)
        } else {
          this.items.push(this.editedItem)
        }
        this.close()
      }
    },
    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'Crear departamento' : 'Editar departamento'
      },
    },
    watch: {
      dialog(val) {
        val || this.close()
      }
    },
  }
</script>

<style lang="sass">
  header.index-table-header
    border-radius: 3px 3px 0px 0px 
</style>