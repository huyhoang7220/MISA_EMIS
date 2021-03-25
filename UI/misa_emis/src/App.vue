<template>
  <div id="app">
    <Menu/>
    <div  class="right-box">
      <Header/>
      <Content/>
    </div>
    
  </div>
</template>

<script>
import Menu from './components/layout/Menu.vue'
import Header from './components/layout/Header.vue'
import Content from './components/layout/Content.vue'

export default {
  name: 'App',
  components: {
    Menu,
    Header,
    Content,
  }
}
</script>

<style>
body{
  width: 100%;
  height: 100vh;
  margin: 0px;
  background-color: #EAECEF;
}
@font-face{
  font-family: OpenSan-Regular;
  src: url('./assets/Fonts/OpenSans-Regular.ttf');
}
@font-face {
  font-family: OpenSan-Bold;
  src: url('./assets/Fonts/OpenSans-Bold.ttf');
}
@font-face {
  font-family: OpenSan-Semibold;
  src: url('./assets/Fonts/OpenSans-Semibold.ttf');
}
@font-face {
  font-family: OpenSan-Italic;
  src: url('./assets/Fonts/OpenSans-Italic.ttf');
}
#app {
  font-family: OpenSan-Regular;
  margin: 0px;
  width: 100%;
  display: flex;
}
.right-box{
  width: calc(100% - 220px);
}
select, input{
  font-family: OpenSan-Regular;
}
</style>
