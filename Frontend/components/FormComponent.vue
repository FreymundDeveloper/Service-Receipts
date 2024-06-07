<template>
  <form @submit.prevent="submitForm">
    <v-btn-toggle v-model="mode" class="mb-4">
      <v-btn value="register">Registration Mode</v-btn>
      <v-btn value="edit">Edit Mode</v-btn>
    </v-btn-toggle>

    <v-text-field v-model="editId" v-if="mode === 'edit'" label="ID" :rules="numberTypeRules" required></v-text-field>

    <v-select v-model="formData.serviceType" :items="serviceTypesItems" :rules="serviceTypeRules" label="Service Type" required ></v-select>
    <v-textarea v-model="formData.description" :rules="descriptionRules" label="Description" required></v-textarea>
     <v-menu ref="menu" v-model="menu" :close-on-content-click="false" :nudge-right="40" transition="scale-transition"
        offset-y min-width="auto">
      <template v-slot:activator="{ on, attrs }">
        <v-text-field v-model="formData.serviceDate" label="Service Date" prepend-icon="mdi-calendar"
          readonly v-bind="attrs" v-on="on" required></v-text-field>
      </template>
      <v-date-picker v-model="formData.serviceDate" no-title scrollable @input="menu = false"></v-date-picker>
    </v-menu>
    <v-text-field v-model.number="formData.receipt.cost" label="Cost (US$)" required :rules="costRules" @focus="numberTypeRules"></v-text-field>
    <v-text-field v-model.number="formData.receipt.amountCharged" label="Amount Charged (US$)" required :rules="numberTypeRules" @focus="clearAmountCharged"></v-text-field>

    <v-btn type="submit" color="primary" :disabled="!formIsValid">{{ mode === 'register' ? 'Register' : 'Edit' }}</v-btn>
  </form>
</template>

<script>
export default {
  data() {
    return {
      menu: false,
      mode: 'register',
      editId: '',
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
  computed: {
    numberTypeRules() {
      return [
        v => !!v || 'Item is required',
        v => /^[0-9]+(\.[0-9]{1,2})?$/.test(v) || 'Enter a valid number'
      ];
    },
    serviceTypeRules() {
      return [v => (v !== null && v !== undefined) || 'Item is required'];
    },
    descriptionRules() {
      return [v => !!v || 'Item is required'];
    },
    costRules() {
      return [
        v => !!v || 'Item is required',
        v => /^[0-9]+(\.[0-9]{1,2})?$/.test(v) || 'Enter a valid number'
      ];
    },
    amountChargedRules() {
      return [
        v => !!v || 'Item is required',
        v => /^[0-9]+(\.[0-9]{1,2})?$/.test(v) || 'Enter a valid number'
      ];
    },
    formIsValid() {
      return (
        this.formData.serviceType !== null &&
        this.formData.description.trim() !== '' &&
        this.formData.serviceDate.trim() !== '' &&
        this.formData.receipt.cost !== null &&
        this.formData.receipt.amountCharged !== null &&
        (this.mode === 'register' || (!!this.editId && this.editId.trim() !== ''))
      );
    }
  },
  methods: {
    submitForm() {
      const url = this.mode === 'register' ? 'https://localhost:7136/Api/Historic' : `https://localhost:7136/Api/Historic/${this.editId}`;
      const method = this.mode === 'register' ? 'post' : 'put';
      this.$axios[method](url, this.formData)
        .then(response => {
          console.log(this.mode === 'register' ? 'Formulário registrado:' : 'Formulário editado:', response.data);
          window.location.reload();
        })
        .catch(error => {
          console.error('Erro ao enviar formulário:', error);
        });
    },
    clearCost() {
      if (this.formData.receipt.cost === 0) {
        this.formData.receipt.cost = null;
      }
    },
    clearAmountCharged() {
      if (this.formData.receipt.amountCharged === 0) {
        this.formData.receipt.amountCharged = null;
      }
    },
  },
};
</script>
