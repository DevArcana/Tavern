export const getters = {
  isAuthenticated(state: { auth: { loggedIn: boolean } }) {
    return state.auth.loggedIn
  },

  loggedInUser(state: { auth: { user: any } }) {
    return state.auth.user
  }
}