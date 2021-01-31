<template>
<div class="albumContainer">
  <div v-if="!loading" class="row">
    <hgroup class="headings">
      <h2 class="artist">{{album?.artist}}</h2>
      <h1 class="title">{{album?.title}}</h1>
    </hgroup>
    <div v-if="album.spotifyUrl != null" class="spotify">
      <iframe frameborder="0" width="100%;" height="100%;" allowtransparency="true" allow="encrypted-media" :src='album?.spotifyUrl'></iframe>
    </div>
    <div v-else class="notOnSpotify">
      Not on Spotify
    </div>
    <div class="scoreBox">
      <span class="score">
        {{album?.score}}
      </span>
    </div>
  </div>
  <div v-else class="spinnerContainer">
    <Circle4/>
  </div>
</div>
</template>

<script>
import axios from 'axios';
import {
  Circle4
} from 'vue-loading-spinner';

export default {
  name: "AlbumRecommendations",
  components: {
    Circle4
  },
  data() {
    return {
      album: null,
      loading: true

    }
  },
  created() {
    setTimeout(() => {
      this.getAlbum();
    }, 2000);
  },

  methods: {
    getAlbum: function() {
      axios.get('https://albumrecommendationswebapi20210130224025.azurewebsites.net/albums/suggestion?maxYear=2010&minYear=2020&minScore=85')
        .then(response => {
          this.album = response.data;
          this.loading = false;
        })
        .catch(e => {
          this.errors.push(e)
        })
    }
  }
}
</script>

<style scoped>
#app {
  background-color: #f7f7f7;
}

.albumContainer {
  background: #fff;
  padding: 20px 0 40px;
  margin-top: 2%;
  margin-left: 20%;
  margin-right: 20%;
  position: relative;
}

.row {
  display: flex;
  -webkit-box-align: center;
  align-items: center;
  margin-left: -20px;
  margin-right: -20px;
  box-sizing: border-box;
}

.headings {
  position: relative;
  min-height: 1px;
  margin-top: 20px;
  margin-bottom: 20px;
  padding-right: 20px;
  text-align: center;
  color: #1a1a1a;
  padding-left: 60px;
  width: 50%;
  display: block;
}

.artist {
  font-family: Walfork, Walsheim, Helvetica Neue, Helvetica, Arial, sans-serif;
  font-size: 175%;
  bottom: .25em;
  font-weight: 400;
  padding-right: 20px;
}

.title {
  font-family: Tiempos Headline, Tiempos, Georgia, serif;
  font-size: 250%;
  line-height: 1.25;
  font-weight: 700;
  font-style: italic;
  margin: 0;
}


.spotify {
  margin-left: 0%;
  float: left;
  width: 20rem;
  height: 20rem;
  min-height: 1px;
  position: relative;
}

.notOnSpotify {
  width: 20rem;
  height: 20rem;
  background-image: linear-gradient(rgba(0, 0, 0, .6), #121212);
  color: white;
  font-size: 20px;
  font-weight: 700;
  line-height: 20rem;
  letter-spacing: normal;
  text-align: center;
  text-transform: none;
}

.scoreBox {
  position: relative;
  min-height: 1px;
  padding-left: 20px;
  padding-right: 20px;
  text-align: center;
  margin-left: 2%;
  margin-right: 3%;
}

.score {
  border-radius: 5rem;
  width: 5rem;
  height: 5rem;
  padding: 2rem;
  background: white;
  border: .75rem solid black;
  text-align: center;
  color: black;
  font-size: 3rem;
  font-weight: 700;
}

.spinnerContainer {
  padding-left: 50%;
  align-items: center;
}
</style>
