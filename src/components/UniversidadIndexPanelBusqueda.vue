<template>
  <CartaFormulario titulo="Buscar">
    <template v-slot:form>
      <v-row>
        <v-col
          cols="12"
          md="6"
        >
          <v-text-field
            v-model="codigo"
            label="Codigo"
            name="codigo"
            type="text"
          />
        </v-col>

        <v-col
          cols="12"
          md="6"
        >
          <v-text-field
            v-model="nombre"
            label="Nombre"
            name="nombre"
            type="text"
          />
        </v-col>
      </v-row>
    </template>
    <template v-slot:btn>
      <v-btn
        color="primary"
        class="pl-3 pr-3"
      >
        Buscar
      </v-btn>
    </template>
  </CartaFormulario>
</template>

<script>
  import CartaFormulario from '@/components/CartaFormulario'

  export default {
    components: {
      CartaFormulario
    },
    data() {
      return {
        codigo: '',
        nombre: '',
      }
    }
  }
</script>