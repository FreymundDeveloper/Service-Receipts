<template>
  <v-card>
    <v-card-title>Receipt</v-card-title>
    <v-data-table :headers="headers" :items="items"></v-data-table>
  </v-card>
</template>

<script>
export default {
  data() {
    return {
      headers: [
        { text: 'ID', value: 'id' },
        { text: 'Cost', value: 'cost' },
        { text: 'Amount Charged', value: 'amountCharged' },
        { text: 'Profit', value: 'profit' }
      ],
      items: [],
    };
  },
  mounted() {
    this.fetchReceipts();
  },
  methods: {
    fetchReceipts() {
      this.$axios.get('https://localhost:7136/Api/Receipt')
        .then(response => {
          this.items = response.data;
        })
        .catch(error => {
          console.error('Error fetching receipts:', error);
        });
    },
  },
};
</script>
