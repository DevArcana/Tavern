<template>
  <div class="card">
    <header class="card-header is-block">
      <div>
        <p class="card-header-title">
          New project
        </p>
      </div>
      <div>
        <b-taglist class="card-header-title roles-list">
          <b-tag type="is-info">Coffee maker</b-tag>
          <b-tag type="is-info">Garbage collector</b-tag>
          <b-tag type="is-info">Motivator</b-tag>
          <b-tag type="is-info">Other</b-tag>
        </b-taglist>
      </div>
    </header>
    <div class="card-content">
      <div class="content">
        <div>
          Lorem ipsum dolor sit, amet consectetur adipisicing elit. Autem consequatur quidem nesciunt nihil soluta eos dignissimos nostrum optio aperiam, laboriosam laudantium at alias veniam quae sunt accusantium porro distinctio est.
          Officiis, provident. Hic facilis doloribus perspiciatis ab debitis at, error, vel eligendi fuga enim voluptate voluptatibus ea ut recusandae iste natus, dicta blanditiis? Provident ratione facilis similique. Quod, ipsam autem!
          Explicabo illo accusantium, at delectus harum assumenda unde voluptas quos vitae aperiam? Ipsam qui distinctio illum, nihil, cupiditate reiciendis provident eius possimus quis iure aspernatur eligendi quas sint deserunt nam.
          Non iure deserunt vel necessitatibus tempore, ipsum explicabo ad ut iusto assumenda distinctio quis ea, est qui aperiam esse voluptates reprehenderit molestias labore, minus quo! Mollitia at velit provident voluptatum.
          Harum necessitatibus dicta aspernatur laudantium modi eum nesciunt pariatur qui quas molestiae quam dolorum laboriosam, vel veritatis aliquam, excepturi voluptatibus fugit eligendi id minus? Necessitatibus quidem temporibus veniam iste magni?
          Iste magnam accusantium eum temporibus tempore provident sit aliquam praesentium deleniti expedita minima quos molestiae, aliquid cupiditate est blanditiis voluptatem commodi beatae, inventore quia. At nisi atque dolor vitae adipisci!
          Exercitationem soluta, laudantium rem repellendus doloremque, cumque fugit, debitis aliquam eos iusto saepe sed. Tempora maiores sit aliquam eaque harum necessitatibus voluptatem vero tempore facere, voluptate, nostrum culpa magnam ad?
          Iste mollitia repudiandae tempora, nesciunt doloremque accusamus perferendis labore harum. Facere cupiditate blanditiis id reprehenderit dolorem aut exercitationem culpa doloribus. Voluptatem, ex illum maxime praesentium obcaecati sapiente quidem eligendi dolorum.
          Qui nemo, voluptates iusto tenetur delectus ut quidem repellat neque et autem officiis necessitatibus odit excepturi assumenda fuga, quam ducimus, beatae vel dicta? Voluptas pariatur, esse cupiditate dolor excepturi quo!
          Rerum, quibusdam! Ea, error. Voluptas doloremque quae modi quas. Cum explicabo, debitis repudiandae nemo ipsa qui voluptas nam quos illo rerum, excepturi animi sunt accusamus nesciunt tempora architecto dignissimos earum!
          Neque atque quisquam quam ab debitis nam dolorum magnam veniam mollitia reiciendis. Illo cumque aspernatur perferendis blanditiis, incidunt consectetur assumenda, odit quo corrupti ipsam consequatur, saepe unde nobis aperiam expedita!
          Qui perspiciatis vitae sapiente labore accusantium molestias ut quod id ullam nobis doloribus tempore dolorum a corrupti et facere sunt totam ab pariatur hic illo, nisi explicabo incidunt! Laboriosam, corporis.
        </div>
        <div class="veil"></div>
      </div>
    </div>
    <footer class="card-footer">
      <a href="#" class="card-footer-item">Details</a>
    </footer>
  </div>
</template>

<script>
export default {

}
</script>

<style scoped>
.card-header-title {
  padding-bottom: 0;
}
.roles-list {
  padding-top: 6px;
  font-weight: 500;
}
.content {
  max-height: 120px;
  position: relative;
  overflow: hidden;
}
.content .veil { 
  position: absolute; 
  bottom: 0; 
  left: 0;
  width: 100%; 
  text-align: center; 
  margin: 0; padding: 30px 0; 
	
  /* "transparent" only works here because == rgba(0,0,0,0) */
  background-image: linear-gradient(to bottom, transparent, white);
}

.card-content {
  padding-bottom: 0;
}
</style>