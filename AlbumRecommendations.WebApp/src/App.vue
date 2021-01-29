<template>
  <br>
<img class="logo" alt="Vue logo" src="./assets/pitchfork.png">
<div class="page">
  <br>
  <h1>Pitchfork Recommends:</h1>
  <AlbumRecommendations :album='album' />
</div>
</template>

<script>
import AlbumRecommendations from './components/AlbumRecommendations.vue'
export default {
  name: 'App',
  components: {
    AlbumRecommendations
  },
  data() {
    return {
      album: {
        title: 'To Pimp a Butterfly',
        artist: 'Kendrick Lamar',
        spotifyUrl: "http://open.spotify.com/embed/album/7ycBtnsMtyVbbwTfJwRjSP",
        year: 2015,
        score: 93,
        genre: 'Hip Hop'
      }
    }
  }
}
</script>

<style>
*{
  margin: 0px;
}

#app {
  font-family: Walfork, Walsheim, Helvetica Neue, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  background-color: #f7f7f7;

}

.page {
  padding-bottom: 4%;
}

img.logo {
  height: 400px;
  width: 400px;
}
</style>
