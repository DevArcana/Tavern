<template>
  <div class="notification is-danger">
    {{ message }}
  </div>
</template>

<script lang="ts">
import Vue from "vue"

export default Vue.extend({
  props: {
    message: {
      type: String,
      required: true
    }
  }
})
</script>