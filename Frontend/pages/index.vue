<template>
  <v-container>
    <v-layout row wrap>
      <v-flex xs12 md5 class="pa-2">
        <v-card>
          <v-card-title>
            Registration Form
          </v-card-title>
          <v-card-text>
            <FormComponent :editItemId="editItemId" />
          </v-card-text>
        </v-card>
      </v-flex>

      <v-flex xs12 md7 class="pa-2">
        <v-card>
          <v-card-text>
            <div v-if="showTableOption === 1"><HistoricTable /></div>
            <div v-else><ReceiptTable @edit-item="handleEditItem" /></div>
          </v-card-text>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import HistoricTable from '../components/HistoricTable.vue';
import ReceiptTable from '../components/ReceiptTable.vue';
import FormComponent from '../components/FormComponent.vue';

export default {
  components: { HistoricTable, ReceiptTable, FormComponent },
  name: 'IndexPage',
  data() {
    return {
      showTableOption: 1,
      editItemId: null,
    };
  },
  mounted() {
    this.$root.$on('changeTable', this.handleTableChange);
  },
  beforeDestroy() {
    this.$root.$off('changeTable', this.handleTableChange);
  },
  methods: {
    handleTableChange(option) {
      this.showTableOption = option;
    },
    handleEditItem(itemId) {
      this.editItemId = itemId;
    }
  }
}
</script>
