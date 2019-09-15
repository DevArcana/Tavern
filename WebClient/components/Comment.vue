<template>
<div class="card">
  <div class="card-content">{{comment.content}}</div>
  <div class="card-content" v-if="comment.children">
    <Comment v-for="child in comment.children" :key="child.id" :comment="child"></Comment>
  </div>
</div>
</template>

<script lang="ts">
import Vue, { PropOptions } from "vue"
import Project from "~/models/Project";
import Comment from "~/models/Comment";

export default Vue.extend({
  props: {
    comment: {
      type: Object,
      required: true
    } as PropOptions<Comment>,
  }
});
</script>

<style>
</style>