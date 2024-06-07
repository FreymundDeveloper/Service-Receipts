<template>
  <form @submit.prevent="submitForm">
    <v-select v-model="formData.serviceType" :items="serviceTypesItems" :rules="[v => !!v || 'Item is required']" label="Service Type" required ></v-select>
    <v-textarea v-model="formData.description" label="Description" required></v-textarea>
     <v-menu ref="menu" v-model="menu" :close-on-content-click="false" :nudge-right="40" transition="scale-transition"
      offset-y min-width="auto" >
      <template v-slot:activator="{ on, attrs }">
        <v-text-field v-model="formData.serviceDate" label="Service Date" prepend-icon="mdi-calendar"
          readonly v-bind="attrs" v-on="on" required ></v-text-field>
      </template>
      <v-date-picker v-model="formData.serviceDate" no-title scrollable @input="menu = false" ></v-date-picker>
    </v-menu>
    <v-text-field v-model="formData.receipt.cost" label="Cost" required></v-text-field>
    <v-text-field v-model="formData.receipt.amountCharged" label="Amount Charged" required></v-text-field>
    <v-btn type="submit" color="primary">Enviar</v-btn>
  </form>
</template>

<script>
export default {
  data() {
    return {
      menu: false,
      formData: {
        description: '',
        serviceDate: new Date().toISOString().slice(0, 10),
        serviceType: null,
        receipt: {
          cost: 0,
          amountCharged: 0,
        },
      },
      serviceTypesItems: [
        { text: 'Cleaning', value: 0 },
        { text: 'Software Update', value: 1 },
        { text: 'Hardware Replacement', value: 2 },
      ],
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
