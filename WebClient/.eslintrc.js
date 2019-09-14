// module.exports = {
//   root: true,
//   env: {
//     browser: true,
//     node: true
//   },
//   parserOptions: {
//     parser: 'babel-eslint'
//   },
//   extends: [
//     '@nuxtjs',
//     'plugin:nuxt/recommended'
//   ],
//   // add your custom rules here
//   rules: {
//   }
// }

module.exports = {
  root: true,
  env: {
    browser: true,
    node: true
  },
  parserOptions: {
    parser: 'babel-eslint'
  },
  extends: [
    '@nuxtjs/eslint-config-typescript'
  ],
  rules: {
    "no-unused-vars": "off",
    "@typescript-eslint/no-unused-vars": ["error", {
      "vars": "all",
      "args": "none",
      "ignoreRestSiblings": false
    }],
    "quotes": "off",
    "@typescript-eslint/quotes": ["error", "double"],
    "semi": "off",
    "@typescript-eslint/semi": ["error", "always"]
  }
}