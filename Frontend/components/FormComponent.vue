<template>
  <form @submit.prevent="submitForm">
    <v-text-field v-model="formData.description" label="Description" required></v-text-field>
    <v-text-field v-model="formData.serviceDate" label="Service Date" required></v-text-field>
    <v-text-field v-model="formData.serviceType" label="service Type" required></v-text-field>
    <v-text-field v-model="formData.receipt.cost" label="Cost" required></v-text-field>
    <v-text-field v-model="formData.receipt.amountCharged" label="Amount Charged" required></v-text-field>
    <v-btn type="submit" color="primary">Enviar</v-btn>
  </form>
</template>

<script>
export default {
  data() {
    return {
      formData: {
        description: '',
        serviceDate: null,
        serviceType: null,
        receipt: {
          cost: null,
          amountCharged: null,
        },
      },
    };
  },
  methods: {
    submitForm() {
      this.$axios.post('/Api/Historic', this.formData)
        .then(response => {
          console.log('Form submitted:', response.data);
        })
        .catch(error => {
          console.error('Error submitting form:', error);
        });
    },
  },
};
</script>
