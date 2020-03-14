<template>
  <v-card>
    <v-toolbar
      color="primary"
      dark
      dense
      flat
    >
    <v-card-title>Buscar Universidades</v-card-title>
    </v-toolbar>

    <v-card-text>
      <v-form>
        <v-container>
          <v-row>
            <v-col
              cols="12"
              md="6"
            >
              <v-text-field
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
                label="Nombre"
                name="nombre"
                type="text"
              />
            </v-col>
          </v-row>
        </v-container>
      </v-form>
    </v-card-text>

    <v-card-actions>
      <v-spacer />
      <v-btn
        color="primary"
      >
        Buscar
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
  import { API } from '../backend'

  export default {
    data() {
      return {}
    }
  }
</script>