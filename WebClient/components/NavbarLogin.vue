<template>
  <b-dropdown position="is-bottom-left" aria-role="menu">
    <a
      slot="trigger"
      class="navbar-item"
      role="button"
    >
      <span>Login</span>
      <b-icon icon="menu-down" />
    </a>

    <b-dropdown-item
      aria-role="menu-item"
      :focusable="false"
      custom
    >
      <form action="" method="post" @submit.prevent="validate">
        <b-field
          label="Username"
          :type="{'is-danger': errors.has('username')}"
          :message="errors.first('username')"
        >
          <b-input v-model="username" v-validate="'required|alpha'" type="text" name="username" />
        </b-field>

        <b-field
          label="Email"
          :type="{'is-danger': errors.has('email')}"
          :message="errors.first('email')"
        >
          <b-input v-model="email" v-validate="'required|email'" type="email" name="email" />
        </b-field>

        <b-field
          label="Password"
          :type="{'is-danger': errors.has('password')}"
          :message="errors.first('password')"
        >
          <b-input v-model="password" v-validate="'required|min:8'" type="password" name="password" />
        </b-field>

        <button type="submit" class="button is-primary">
          Login
        </button>
      </form>
    </b-dropdown-item>
  </b-dropdown>
</template>

<script lang="ts">
import Vue from 'vue'

class Data {
  username: string = ''
  email: string = ''
  password: string = ''
}

export default Vue.extend({
  data () {
    return new Data()
  },
  methods: {
    async validate () {
      // @ts-ignore
      const result = await this.$validator.validateAll()

      if (result) {
        // @ts-ignore
        await this.$auth.loginWith('local', {
          data: {
            username: this.username,
            password: this.password
          }
        })
      }
    }
  }
})
</script>

<style>

</style>
