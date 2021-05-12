<template>
  <div class="body-left">
    <div class="sidebar">
      <div class="toggle" @click="toggleMenu"></div>
      <div class="logo" :class="{ isToggle: isToggle }"></div>
    </div>
    <div class="menu">
      <router-link
        v-for="(item, index) in menuItem"
        :key="index"
        :to="item.path"
      >
        <div class="menu-item">
          <div :class="item.class"></div>
          <div class="item-name" :class="{ isToggle: isToggle }">
            {{ item.name }}
          </div>
        </div>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "TheSideBar",
  data() {
    return {
      menuItem: [
        {
          path: "",
          class: "icon icon-overview",
          name: "Tổng quan",
        },
        {
          path: "",
          class: "icon icon-money",
          name: "Tiền mặt",
        },
        {
          path: "",
          class: "icon icon-deposit",
          name: "Tiền gửi",
        },
        {
          path: "",
          class: "icon icon-purchase",
          name: "Mua hàng",
        },
        {
          path: "/Employee",
          class: "icon icon-sell",
          name: "Bán hàng",
        },
        {
          path: "",
          class: "icon icon-bill",
          name: "Quản lý hoá đơn",
        },
        {
          path: "",
          class: "icon icon-storeroom",
          name: "Kho",
        },
        {
          path: "",
          class: "icon icon-tool",
          name: "Công cụ dụng cụ",
        },
      ],
    };
  },
  computed: {
    isToggle() {
      return this.$store.getters.getToggle;
    },
  },
  methods: {
    toggleMenu() {
      this.$store.commit("toggleSideBar");
    },
  },
};
</script>

<style>
a {
  text-decoration: none;
  color: #fff;
}
.body-left {
  background-color: #38393d;
  width: 178px;
  height: 100vh;
  border-right: 1px solid #bbbbbb;
  display: flex;
  flex-direction: column;
}

.body-left .sidebar {
  height: 50px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.body-left .sidebar .toggle {
  width: 24px;
  height: 24px;
  margin-right: 10px;
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -424px -86px;
  cursor: pointer;
}

.body-left .sidebar .logo {
  width: 96px;
  height: 32px;
  background-image: url("../assets/img/Logo_Module_TiengViet_White.66947422.svg");
  background-size: 97px;
  background-repeat: no-repeat;
  background-position: center;
  cursor: pointer;
}

.body-left .menu {
  display: flex;
  padding-top: 10px;
  flex-direction: column;
}

.body-left .menu .menu-item {
  display: flex;
  align-items: center;
  cursor: pointer;
  height: 42px;
  border-left: 6px solid transparent;
  padding: 0px 0px 0px 8px;
}

.body-left .menu .menu-item:hover {
  background-color: #616164;
}

.body-left .menu .menu-item .icon {
  width: 24px;
  height: 24px;
  background-repeat: no-repeat;
  background-size: 24px;
  background-position: 18px center;
  margin-right: 8px;
}

.body-left .menu .menu-item .icon-overview {
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -30px -1628px;
}

.body-left .menu .menu-item .icon-money {
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -73px -1628px;
}

.body-left .menu .menu-item .icon-purchase {
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -161px -1628px;
}

.body-left .menu .menu-item .icon-deposit {
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -117px -1628px;
}

.body-left .menu .menu-item .icon-sell {
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -204px -1628px;
}

.body-left .menu .menu-item .icon-bill {
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -161px -1628px;
}

.body-left .menu .menu-item .icon-storeroom {
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -291px -1628px;
}

.body-left .menu .menu-item .icon-tool {
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -336px -1628px;
}

.body-left .menu .menu-item .item-name {
  width: 150px;
}

.isToggle {
  display: none;
}
</style>
