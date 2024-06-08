<template>
  <form @submit.prevent="submitForm">
    <v-btn-toggle v-model="mode" class="mb-4">
      <v-btn value="register">Registration Mode</v-btn>
      <v-btn value="edit">Edit Mode</v-btn>
    </v-btn-toggle>

    <v-text-field v-model="editId" v-if="mode === 'edit'" label="Historic ID" :rules="numberTypeRules" required></v-text-field>

    <v-select v-model="formData.serviceType" :items="serviceTypesItems" :rules="serviceTypeRules" label="Service Type" required></v-select>
    <v-textarea v-model="formData.description" :rules="descriptionRules" label="Description" required></v-textarea>
    <v-menu ref="menu" v-model="menu" :close-on-content-click="false" :nudge-right="40" transition="scale-transition"
      offset-y min-width="auto">
      <template v-slot:activator="{ on, attrs }">
        <v-text-field v-model="formData.serviceDate" label="Service Date" prepend-icon="mdi-calendar"
          readonly v-bind="attrs" v-on="on" required></v-text-field>
      </template>
      <v-date-picker v-model="formData.serviceDate" no-title scrollable @input="menu = false"></v-date-picker>
    </v-menu>
    <v-text-field v-model.number="formData.receipt.cost" label="Cost (US$)" required :rules="numberTypeRules" @focus="clearCost"></v-text-field>
    <v-text-field v-model.number="formData.receipt.amountCharged" label="Amount Charged (US$)" required :rules="numberTypeRules" @focus="clearAmountCharged"></v-text-field>

    <v-btn type="submit" color="primary" :disabled="!formIsValid">{{ mode === 'register' ? 'Register' : 'Edit' }}</v-btn>
  </form>
</template>

<script>
export default {
  props: {
    editItemId: {
      type: Number,
      default: null,
    }
  },
  watch: {
  editItemId(newId) {
    if (newId != null) {
      this.editId = newId;
      this.fetchHistoricItem(newId);
      this.mode = 'edit';
    } else {
      this.editId = '';
    }
  }
},
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
    formIsValid() {
      const isValidCost = this.formData.receipt.cost !== null && /^\d+(\.\d{1,2})?$/.test(this.formData.receipt.cost);
      const isValidAmountCharged = this.formData.receipt.amountCharged !== null && /^\d+(\.\d{1,2})?$/.test(this.formData.receipt.amountCharged);
      const isValidId = this.mode === 'register' || (!!this.editId && /^\d+$/.test(String(this.editId).trim()));

      return (
        this.formData.serviceType !== null &&
        this.formData.description.trim() !== '' &&
        this.formData.serviceDate.trim() !== '' &&
        isValidCost &&
        isValidAmountCharged &&
        isValidId
      );
    }
  },
  methods: {
    submitForm() {
      const url = this.mode === 'register' ? 'https://localhost:7136/Api/Historic' : `https://localhost:7136/Api/Historic/${this.editId}`;
      const method = this.mode === 'register' ? 'post' : 'put';
      this.$axios[method](url, this.formData)
        .then(response => {
          console.log(this.mode === 'register' ? 'Registered form:' : 'Edited form:', response.data);
          window.location.reload();
        })
        .catch(error => {
          console.error('Error submitting form:', error);
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
    setFormData(item) {
      this.editId = item.id;
      this.formData.description = item.description;
      this.formData.serviceDate = this.formatDate(item.serviceDate);
      this.formData.serviceType = item.serviceType;
      this.formData.receipt.cost = parseFloat(item.receipt.cost);
      this.formData.receipt.amountCharged = parseFloat(item.receipt.amountCharged);
      this.mode = 'edit';
    },
    formatDate(dateString) {
      const date = new Date(dateString);
      const year = date.getFullYear();
      const month = String(date.getMonth() + 1).padStart(2, '0');
      const day = String(date.getDate()).padStart(2, '0');
      return `${year}-${month}-${day}`;
    },
    fetchHistoricItem(itemId) {
      this.$axios.get(`https://localhost:7136/Api/Historic/${itemId}`)
        .then(response => {
          this.setFormData(response.data);
        })
        .catch(error => {
          console.error('Error when searching for item:', error);
        });
    }
  }
};
</script>
