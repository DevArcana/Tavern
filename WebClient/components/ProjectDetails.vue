<template>
<div>
  <div class="box">
    <div class="content">
      <h1>{{ project.title }}</h1>
      <h4>{{ project.category.name }}</h4>
      <p>{{ project.description }}</p>
      <b-taglist>
        <b-tag v-for="role in project.functions" :key="role.id" type="is-info">{{role.name}}</b-tag>
      </b-taglist>
    </div>
  </div>

  <div class="box">
    <div class="content">
      <form action="" method="post" @submit.prevent="submitComment">
        <b-field label="Comment on this project">
          <b-input type="textarea"
            v-model="comment"
            minlength="1"
            maxlength="100"
            placeholder="Comment">
          </b-input>
        </b-field>
        <button type="submit" class="button is-primary is-fullwidth">Post comment</button>
      </form>
    </div>
  </div>

  <div class="box">
    <div class="content">
      <h3>Comment Section</h3>
      <div v-for="comment in comments" :key="comment.id" class="card">{{ comment.content }}</div>
    </div>
  </div>
</div>
</template>

<script lang="ts">
import Vue, { PropOptions } from "vue"
import Project from "~/models/Project";
import Comment from "~/models/Comment";

export default Vue.extend({
  data() {
    return {
      comment: "",
      comments: [{id:1, content: "Test", projectId: 1, children: []}]
    } as {
      comment: string;
      comments: Comment[];
    }
  },
  
  methods: {
    async submit() {
      try {
        const response = await this.$axios.post("projects", {
          projectId: this.project.id,
          content: this.comment
        });


      } catch (e) {
        console.log(e);
      }
    },
  },

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