<!-- components/ReceiptTable.vue -->
<template>
  <v-card>
    <v-card-title>Recibo</v-card-title>
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
      this.$axios.get('/Api/Receipts')
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
