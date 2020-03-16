<template>
  <CartaFormulario titulo="Buscar">
    <template v-slot:form>
      <v-row>
        <v-col
          cols="12"
          md="6"
        >
          <v-text-field
            v-model="filtro.codigo"
            label="Codigo"
            name="codigo"
            type="text"
            v-on:keyup.enter="filtrar()"
          />
        </v-col>

        <v-col
          cols="12"
          md="6"
        >
          <v-text-field
            v-model="filtro.nombre"
            label="Nombre"
            name="nombre"
            type="text"
            v-on:keyup.enter="filtrar()"
          />
        </v-col>
      </v-row>
    </template>
    <template v-slot:btn>
      <v-btn
        color="primary"
        class="pl-3 pr-3"
        @click="filtrar()"
      >
        Buscar
      </v-btn>
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
        filtro: {
          codigo: '',
          nombre: '',
        }
      }
    },
    methods: {
      filtrar() {
        this.$store.commit('universidades/filtrar', this.filtro)
      }
    }
  }
</script>