<template>
  <nav class="navbar is-dark fixed-top" role="navigation" aria-label="main navigation">
    <div class="navbar-brand">
      <a class="navbar-item">
        <img class="logo-desktop is-hidden-touch"
          src="~/assets/logo.png"
          alt="Tavern Social Platform"
        />
      </a>
      <a class="navbar-item">
        <img class="logo-mobile is-hidden-desktop"
          src="~/assets/logo.png"
          alt="Tavern Social Platform"
        />
      </a>

      <a role="button" class="navbar-burger burger" aria-label="menu" aria-expanded="false" data-target="navbarBasicExample">
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
      </a>
    </div>

    <div id="navbarBasicExample" class="navbar-menu">
      <div class="navbar-start">
      </div>

      <div class="navbar-end">
        <div class="navbar-item">
          <div class="buttons">
            <nuxt-link class="button is-primary" to="/register">Sign up</nuxt-link>
            <nuxt-link class="button" to="/login">Log in</nuxt-link>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
export default {};
</script>

<style>
.logo-desktop {
  height: 48px;
  width: 240px;
}
.logo-mobile {
  height: 30px;
  width: 150px;
}
</style>
