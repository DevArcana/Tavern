<template>
  <div class="card">
    <div class="card-content">{{comment.content}}</div>
    <b-collapse class="card-content" :open="false" aria-id="contentIdForA11y1" v-if="isAuthenticated">
      <button class="button is-primary" slot="trigger" aria-controls="contentIdForA11y1" >Reply</button>
      <b-field>
        <form action method="post" @submit.prevent="reply">
          <b-input
            v-model="replyMessage"
            type="textarea"
            minlength="10"
            maxlength="100"
            placeholder="Maxlength automatically counts characters"
          ></b-input>

          <button type="submit" class="button is-primary is-fullwidth">Submit</button>
        </form>
      </b-field>
    </b-collapse>
    <div class="card-content" v-if="comment.children">
      <Comment v-for="child in comment.children" :key="child.id" :comment="child"></Comment>
    </div>
  </div>
</template>

<script lang="ts">
import Vue, { PropOptions } from "vue";
import Project from "~/models/Project";
import Comment from "~/models/Comment";
import { mapGetters } from 'vuex'

export default Vue.extend({
  name: "Comment",
  data() {
    return {
      replyMessage: ""
    } as {
      replyMessage: string;
    };
  },
  methods: {
    async reply() {
      try {
        const response = await this.$axios.post("comments", {
          projectId: this.comment.projectId,
          parentId: this.comment.id,
          content: this.replyMessage
        });

        location.reload();
      } catch (e) {
        console.log(e);
      }
    }
  },
  props: {
    comment: {
      type: Object,
      required: true
    } as PropOptions<Comment>
  },
  computed: {
    ...mapGetters(['isAuthenticated', 'loggedInUser'])
  }
});
</script>

<style>
</style>