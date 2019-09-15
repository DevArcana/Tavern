<template>
  <div class="comment">
    <div class="comment-header"><strong>{{comment.creator.username}}</strong></div>
    <div class="comment-body">{{comment.content}}</div>
    <b-collapse class="comment-reply" :open="false" aria-id="contentId">
      <button class="button is-normal" slot="trigger" aria-controls="contentId">Reply</button>
      <b-field>
        <form action method="post" @submit.prevent="reply">
          <b-input
            v-model="replyMessage"
            type="textarea"
            minlength="1"
            maxlength="256"
            :placeholder="`Your reply to ${comment.creator.username}`"
          ></b-input>

          <button type="submit" class="button is-primary is-fullwidth">Submit</button>
        </form>
      </b-field>
    </b-collapse>
    <div class="comment-children" v-if="comment.children && comment.children.length > 0">
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
.comment {
  color: black;
  background-color: white;
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.3s;
  margin-bottom: 0.5rem;
}

.comment:hover {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

.comment-header {
  padding: 0.5rem 1rem;
  padding-bottom: 0;
}

.comment-body {
  padding: 0.5rem 1rem;
}

.comment-reply {
  padding: 0.5rem 1rem;
  background-color: whitesmoke;
}

.comment-children {
  padding: 0.5rem 1rem;
  padding-top: 0.5rem;
  background-color: #c5c5c5;
}
</style>