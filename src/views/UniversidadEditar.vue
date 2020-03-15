<template>
  <v-card>
    <v-toolbar
      color="primary"
      dark
      dense
      flat
    >
      <v-toolbar-title>{{ this.titulo }}</v-toolbar-title>
    </v-toolbar>

    <v-card-text
      class="pb-0"
    >
      <v-form>
        <v-row>
          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="universidad.codigo"
              label="Código"
              name="codigo"
              type="text"
            />
          </v-col>

          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="universidad.nombre"
              label="Nombre"
              name="nombre"
              type="text"
            />
          </v-col>
        </v-row>
      </v-form>
    </v-card-text>

    <v-card-actions
      class="pa-4 pt-0"
    >
      <v-spacer />
      <v-btn
        color="primary"
        class="pl-3 pr-3"
        @click="guardarUniversidad()"
      >
        Guardar
      </v-btn>
      <v-btn
        class="pl-3 pr-3"
      >
        Cancelar
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
  import { API } from '@/backend'
  import router from '@/router'
  import CartaFormulario from '@/components/CartaFormulario'

  export default {
    components: {
      CartaFormulario
    },
    data() {
      return {
        universidad: {
          id: 0,
          codigo: '',
          nombre: '',
        },
        accion: '',
        titulo: '',
      }
    },
    methods: {
      obtenerAccion() {
        let nombreRuta = this.$route.name

        if (nombreRuta.includes('.crear')) {
          this.accion = 'Crear'
        }
        else if (nombreRuta.includes('.editar')) {
          this.accion = 'Editar'
        }
        this.obtenerTitulo()
      },
      obtenerTitulo() {
        this.titulo = this.accion + ' Universidad'
      },
      guardarUniversidad() {
        if (this.accion == "Crear") {
          API.post(`universidades`, {
            codigo: this.universidad.codigo,
            nombre: this.universidad.nombre,
          })
          .then(response => {
            console.log(response.data)
          })
          .catch(e => {
            console.log(e)
          })
        }
        else if (this.accion == "Editar") {
          console.log(this.universidad)
          API.put(`universidades/${this.universidad.id}`, {
            codigo: this.universidad.codigo,
            nombre: this.universidad.nombre,
          })
          .then(response => {
            console.log(response.data)
          })
          .catch(e => {
            console.log(e)
          })
        }
      }
    },
    created() {
      this.obtenerAccion()
      this.universidad.id = this.$route.params.id ?? 0
      
      if (this.accion == "Editar") {
        API.get(`universidades/${this.universidad.id}`)
        .then(response => {
          this.universidad = response.data
        })
        .catch(e => {
          console.log(e)
        })
      }
    },
  }
</script>