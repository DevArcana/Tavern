<template>
  <div class="box">
    <h2 class="title has-text-centered">Register!</h2>

    <Notification :message="error" v-if="error" />

    <form method="post" @submit.prevent="register">
      <div class="field">
        <label class="label">Username</label>
        <div class="control">
          <input type="text" class="input" name="username" v-model="username" required />
        </div>
      </div>
      <div class="field">
        <label class="label">Email</label>
        <div class="control">
          <input type="email" class="input" name="email" v-model="email" required />
        </div>
      </div>
      <div class="field">
        <label class="label">Password</label>
        <div class="control">
          <input type="password" class="input" name="password" v-model="password" required />
        </div>
      </div>
      <div class="control">
        <button type="submit" class="button is-dark is-fullwidth">Register</button>
      </div>
    </form>

    <div class="has-text-centered" style="margin-top: 20px">
      Already got an account?
      <nuxt-link to="/login">Login</nuxt-link>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue"
import Notification from "~/components/Notification.vue";

export default Vue.extend({
  components: {
    Notification
  },

  data() {
    return {
      username: "",
      email: "",
      password: "",
      error: null
    } as {
      username: string;
      email: string;
      password: string;
      error: string | null;
    };
  },

  methods: {
    async register() {
      try {
        await this.$axios.post("user/register", {
          username: this.username,
          email: this.email,
          password: this.password
        });

        //@ts-ignore
        await this.$auth.loginWith("local", {
          data: {
            username: this.username,
            password: this.password
          }
        });

        this.$router.push("/");
      } catch (e) {
        if (e.response) {
          this.error = e.response.data.message;
        } else {
          this.error = "Failed to get a response.";
        }
      }
    }
  }
});
</script>