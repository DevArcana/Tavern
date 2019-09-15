import https from 'https'

export default ({ $axios }) {
  $axios.defaults.httpsAgent = new https.Agent({ rejectUnauthorized: false })
}