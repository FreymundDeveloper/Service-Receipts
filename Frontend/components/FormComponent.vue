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
        serviceDate: new Date(),
        serviceType: 0,
        receipt: {
          cost: 0,
          amountCharged: 0,
        },
      },
    };
  },
  methods: {
    submitForm() {
      this.$axios.post('https://localhost:7136/Api/Historic', this.formData)
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
