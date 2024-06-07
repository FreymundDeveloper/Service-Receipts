<template>
  <v-container>
    <v-layout row wrap>
      <v-flex xs12 md6>
        <v-card>
          <v-card-title>
            New Registration
          </v-card-title>
          <v-card-text>
            <FormComponent />
          </v-card-text>
        </v-card>
      </v-flex>

      <v-flex xs12 md6>
        <v-card>
          <v-card-text>
            <div v-if="showTableOption === 1"><HistoricTable /></div>
            <div v-else><ReceiptTable /></div>
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
    }
  }
}
</script>
