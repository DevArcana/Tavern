<template>
  <b-navbar class="is-dark fixed-top">
    <template slot="brand">
      <b-navbar-item tag="router-link" :to="{ path: '/' }">
        <img class="logo"
          src="~/assets/logo.png"
          alt="Tavern Social Platform"
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
.navbar {
  height: 5rem;
}

.navbar-item, .navbar-brand, .navbar-burger {
  height: 100%;
}

.logo {
  height: 100%;
  width: auto;
}
</style>
