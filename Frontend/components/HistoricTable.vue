<template>
  <v-card>
    <v-card-title>Historic</v-card-title>
    <v-data-table :headers="headers" :items="items"></v-data-table>
  </v-card>
</template>

<script>
export default {
  data() {
    return {
      headers: [
        { text: 'ID', value: 'id' },
        { text: 'Description', value: 'description' },
        { text: 'Service Date', value: 'serviceDate' },
        { text: 'Service Type', value: 'serviceType' },
        { text: 'Receipt', value: 'receipt.id' }
      ],
      items: [],
    };
  },
  mounted() {
    this.fetchHistoric();
  },
  methods: {
    fetchHistoric() {
      this.$axios.get('https://localhost:7136/Api/Historic')
        .then(response => {
          this.items = response.data;
          console.log(response.data)
        })
        .catch(error => {
          console.error('Error fetching Historic:', error);
        });
    },
  },
};
</script>
