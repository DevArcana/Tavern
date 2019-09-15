<template>
  <div class="box">
    <h1>{{ project.title }}</h1>
    <p>{{ project.description }}</p>
  </div>
</template>

<script lang="ts">
import Vue, { PropOptions } from "vue"
import Project from "~/models/Project";

export default Vue.extend({
  props: {
    project: {
      type: Object,
      required: true
    } as PropOptions<Project>
  }
});
</script>

<style>
</style>