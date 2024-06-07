<template>
  <v-app dark>
    <v-app-bar :clipped-left="clipped" fixed app >
      <v-btn text @click="showHistory">Historic</v-btn>
      <v-btn text @click="showReceipt">Receipt</v-btn>
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>

    <v-footer :absolute="!fixed" app >
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: 'DefaultLayout',
  data () {
    return {
      activeTable: 'history',
      clipped: false,
      drawer: false,
      fixed: true,
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: 'Vuetify.js'
    }
  },
  methods: {
    showHistory() {
      this.activeTable = 'history';
      this.$emit('changeTable', this.activeTable);
    },
    showReceipt() {
      this.activeTable = 'receipt';
      this.$emit('changeTable', this.activeTable);
    },
  }
}
</script>
