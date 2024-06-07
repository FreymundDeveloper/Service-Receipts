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
        { text: 'Cost (US$)', value: 'cost' },
        { text: 'Amount Charged (US$)', value: 'amountCharged' },
        { text: 'Profit (US$)', value: 'profit' }
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
          this.items = response.data.map(item => ({
            ...item,
            cost: this.formatCurrency(item.cost),
            amountCharged: this.formatCurrency(item.amountCharged),
            profit: this.formatCurrency(item.profit),
          }));
        })
        .catch(error => {
          console.error('Error fetching receipts:', error);
        });
    },
    formatCurrency(value) {
      return value.toLocaleString('en-US', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2,
      });
    },
  },
};
</script>
