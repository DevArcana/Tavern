<template>
  <b-navbar class="is-dark">
    <template slot="brand">
      <b-navbar-item tag="router-link" :to="{ path: '/' }">
        <img
          src="~/assets/logo.png"
          alt="Lightweight UI components for Vue.js based on Bulma"
        />
      </b-navbar-item>
    </template>

    <template slot="end">
      <b-navbar-item tag="div">
        <div class="buttons">
          <nuxt-link class="button is-primary" to="/register">Sign up</nuxt-link>
          <nuxt-link class="button" to="/login">Log in</nuxt-link>
        </div>
      </b-navbar-item>
    </template>
  </b-navbar>
</template>

<script>
export default {};
</script>

<style>
</style>
