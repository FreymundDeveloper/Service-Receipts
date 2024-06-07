
<template>
<v-app>
    <template>
      <FormComponent />
    </template>
    <template>
      <HistoricTable />
    </template>
 </v-app>
</template>

<script>
import HistoricTable from '../components/HistoricTable.vue'
import ReceiptTable from '../components/ReceiptTable.vue'
export default {
  components: { HistoricTable, ReceiptTable },
  name: 'IndexPage'
}
</script>

<!--<template>
  <v-app>
    <layout-default @changeTable="changeTable">
      <template #left>
        <component :is="activeComponent"></component>
      </template>
      <template #right>
        <FormComponent />
      </template>
    </layout-default>
  </v-app>
</template>

<script>
import FormComponent from '@/components/FormComponent.vue';
import HistoricTable from '@/components/HistoricTable.vue';
import ReceiptTable from '@/components/ReceiptTable.vue';

export default {
  components: {
    FormComponent,
    HistoricTable,
    ReceiptTable,
  },
  data() {
    return {
      activeComponent: 'HistoricTable',
    };
  },
  methods: {
    changeTable(table) {
      this.activeComponent = table === 'Historic' ? 'HistoricTable' : 'ReceiptTable';
    },
  },
};
</script>-->

