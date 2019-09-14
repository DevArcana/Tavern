<template>
  <div class="box">
    <Notification :message="error" v-if="error" />
    <form action="" method="post" @submit.prevent="submit">
      <b-field label="Title">
        <b-input required validation-message="This field is required" v-model="title"></b-input>
      </b-field>
      
      <b-field label="Description">
        <b-input type="textarea"
          minlength="1"
          maxlength="2048"
          required
          placeholder="Project description"
          v-model="description">
        </b-input>
      </b-field>

      <b-field>
        <button type="submit" class="button is-primary is-fullwidth">Create</button>
      </b-field>
    </form>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Notification from "~/components/Notification.vue"

export default Vue.extend({
  data() {
    return {
      error: null,
      title: "",
      description: ""
    } as {
      error: string | null;
      title: string;
      description: string;
    }
  },
  methods: {
    async submit() {
      console.log(this)
      this.error = "Hello";
    }
  },
  components: {
    Notification
  }
});
</script>

<style>
</style>