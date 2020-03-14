<template>
  <v-container fluid>
    <v-row
      class="justify-center"
    >
      <v-form>
        <v-text-field
          label="Nombre de usuario"
          name="nombre_usuario"
          prepend-icon="person"
          type="text"
        />

        <v-text-field
          label="Contraseña"
          name="password"
          prepend-icon="lock"
          type="password"
        />
      </v-form>
    </v-row>
  </v-container>
</template>

<script>
  export default {
    data: () => ({
    }),
  }
</script>
