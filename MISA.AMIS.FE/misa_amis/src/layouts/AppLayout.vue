<template>
  <div>
    <TheSideBar> </TheSideBar>
    <div class="body-right">
      <TheHeader> </TheHeader>
      <router-view />
    </div>
  </div>
</template>

<script>
import TheSideBar from "./TheSideBar.vue";
import TheHeader from "./TheHeader.vue";

export default {
  name: "AppLayout",
  components: {
    TheSideBar,
    TheHeader,
  },
};
</script>

<style>
div {
  display: flex;
}
.body-right {
  flex: 1;
  top: 0;
  right: 0;
  bottom: 0;
  background-color: bisque;
}
.body-right .content {
  background-color: #ffffff;
  position: absolute;
  top: 50px;
  right: 0;
  bottom: 0;
  left: 0;
  padding: 10px 10px 0px 10px;
}
</style>
