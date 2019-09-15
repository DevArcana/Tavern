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

  <div class="content">
    <Comment v-for="comment in comments" :key="comment.id" :comment="comment"></Comment>
  </div>
</div>
</template>

<script lang="ts">
import Vue, { PropOptions } from "vue"
import Project from "~/models/Project";
import Comment from "~/components/Comment.vue";

export default Vue.extend({
  data() {
    return {
      comment: ""
    } as {
      comment: string;
    }
  },
  
  methods: {
    async submitComment() {
      try {
        const response = await this.$axios.post("comments", {
          projectId: this.project.id,
          content: this.comment
        });

        location.reload();
      } catch (e) {
        console.log(e);
      }
    },
  },

  components: {
    Comment
  },

  props: {
    project: {
      type: Object,
      required: true
    } as PropOptions<Project>,
    comments: {
      type: Array,
      required: true
    } as PropOptions<any[]>
  }
});
</script>

<style scoped>
.comments {
  background-color: white;
}
</style>