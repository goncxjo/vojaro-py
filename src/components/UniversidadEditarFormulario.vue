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

    <v-card-text>
      <v-form
        v-model="isValid"
      >
        <v-row>
          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="universidad.codigo"
              label="Código"
              :rules="reglasCodigo"
              required
              :disabled="readonly"
            />
          </v-col>
          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="universidad.nombre"
              label="Nombre"
              :rules="reglasNombre"
              required
              :disabled="readonly"
            />
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="12">
            <UniversidadDepartamentoTabla
              :items="universidad.departamentos"
              :readonly="readonly"
            ></UniversidadDepartamentoTabla>
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
        :disabled="!isValid"
        @click="save()"
      >
        Guardar
      </v-btn>
      <v-btn
        class="pl-3 pr-3"
        @click="goBack()"
      >
        Cancelar
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
  import router from '@/router'
  import store from '@/store'
  import { mapGetters } from 'vuex'
  import UniversidadDepartamentoTabla  from '@/components/UniversidadDepartamentoTabla'

  export default {
    components: {
      UniversidadDepartamentoTabla
    },
    data() {
      return {
        isValid: true,
        reglasCodigo: [ v => !!v || 'El código es requerido' ],
        reglasNombre: [ v => !!v || 'El nombre es requerido' ],
      }
    },
    methods: {
      save() {
        this.$store.dispatch(`universidades/save`, this.universidad)
        .then(respuesta => this.goBack())
        .catch(e => {
          console.log(e)
        })
      },
      goBack() {
          this.$store.commit(`universidades/clean`)
          router.push({ name: 'universidades.index' })
      }
    },
    created() {
      this.$store.commit(`shared/setTitle`, { 
        routeName: this.$route.name,
        entity: 'Universidad'
      })
      this.$store.dispatch(`universidades/load`, this.$route.params.id ?? 0)
    },
    computed: {
      ...mapGetters('shared', {
        titulo: 'formTitle',
        readonly: 'formReadonly',
      }),
      ...mapGetters('universidades', {
        universidad: 'entity'
      })
    }
}
</script>