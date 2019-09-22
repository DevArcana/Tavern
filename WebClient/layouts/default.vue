<template>
  <div>
    <Navbar />
    <div class="columns">
      <div class="column is-paddingless is-8 is-offset-2">
        <nuxt class="content" />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Navbar from '~/components/Navbar.vue'

export default Vue.extend({
  components: {
    Navbar
  }
})
</script>

<style scoped>
.columns {
  margin-top: 1rem;
}
</style>
