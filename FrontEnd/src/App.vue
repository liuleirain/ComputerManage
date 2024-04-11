<template>
  <header>
    <div class="wrapper">
      <Navbar />
    </div>
  </header>
  <RouterView />
</template>

<script setup lang="ts">
import Navbar from '@/components/Navbar.vue';
import { RouterView } from 'vue-router';
import { onMounted  } from 'vue'
import useStore from '@/stores'
const { auth } = useStore()

onMounted(() =>{
  window.onload = function(){
    if(!window.sessionStorage["login"]){
      auth.handlerLogout()
    }
  };
  window.onunload = function(){
    window.sessionStorage["login"] = true
  };
  window.onbeforeunload = function(){
    window.sessionStorage["login"] = true
  }
})

</script>

<style scoped></style>