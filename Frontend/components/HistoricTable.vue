<template>
  <v-card>
    <v-card-title>Historic</v-card-title>
    <v-data-table :headers="headers" :items="formattedItems"></v-data-table>
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
        { text: 'Receipt (ID)', value: 'receipt.id' }
      ],
      items: [],
    };
  },
  computed: {
    formattedItems() {
      return this.items.map(item => ({
        ...item,
        serviceDate: this.formatDate(item.serviceDate),
        serviceType: this.formatServiceType(item.serviceType),
      }));
    },
  },
  mounted() {
    this.fetchHistoric();
  },
  methods: {
    fetchHistoric() {
      this.$axios.get('https://localhost:7136/Api/Historic')
        .then(response => {
          this.items = response.data;
        })
        .catch(error => {
          console.error('Error fetching Historic:', error);
        });
    },
    formatDate(dateString) {
      const date = new Date(dateString);
      const month = date.getMonth() + 1;
      const day = date.getDate();
      const year = date.getFullYear();
      return `${month}/${day}/${year}`;
    },
    formatServiceType(serviceType) {
      const serviceTypeMap = {
        0: 'Cleaning',
        1: 'Software Update',
        2: 'Hardware Replacement'
      };
      return serviceTypeMap[serviceType];
    },
  },
};
</script>
