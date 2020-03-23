<template>
  <CartaFormulario>
    <template v-slot:form>
      <v-row>
        <v-col
          cols="12"
          md="6"
        >
          <v-text-field
            v-model="filter.codigo"
            label="Codigo"
            name="codigo"
            type="text"
            v-on:keyup="filterCollection()"
          />
        </v-col>

        <v-col
          cols="12"
          md="6"
        >
          <v-text-field
            v-model="filter.nombre"
            label="Nombre"
            name="nombre"
            type="text"
            v-on:keyup="filterCollection()"
          />
        </v-col>
      </v-row>
    </template>
  </CartaFormulario>
</template>

<script>
  import CartaFormulario from '@/components/CartaFormulario'
  import { mapGetters } from 'vuex'

  export default {
    components: {
      CartaFormulario
    },
    data() {
      return {
        filter: {
          codigo: '',
          nombre: '',
        }
      }
    },
    methods: {
      filterCollection() {
        this.$store.commit('universidades/filterCollection', this.filter)
      }
    }
  }
</script>