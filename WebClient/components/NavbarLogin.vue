<template>
  <b-dropdown position="is-bottom-left" aria-role="menu">
    <a slot="trigger" class="navbar-item" role="button">
      <span>Login</span>
      <b-icon icon="menu-down" />
    </a>

    <b-dropdown-item
      aria-role="menu-item"
      :focusable="false"
      custom
      paddingless
    >
      <form action="">
        <div class="modal-card" style="width:300px;">
          <section class="modal-card-body">
            <b-field label="Email">
              <b-input
                type="email"
                placeholder="Your email"
                required
              />
            </b-field>

            <b-field label="Password">
              <b-input
                type="password"
                password-reveal
                placeholder="Your password"
                required
              />
            </b-field>

            <b-checkbox>Remember me</b-checkbox>
          </section>
          <footer class="modal-card-foot">
            <button class="button is-dark">
              Login
            </button>
            <nuxt-link class="button is-dark is-outlined" to="/register">
              Sign up
            </nuxt-link>
          </footer>
        </div>
      </form>
    </b-dropdown-item>
  </b-dropdown>
</template>

<script lang="ts">
import Vue from 'vue'

export default Vue.extend({

})
</script>

<style>

</style>
