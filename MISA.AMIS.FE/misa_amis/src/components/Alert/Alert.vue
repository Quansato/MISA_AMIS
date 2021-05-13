<template>
  <div class="alert">
    <div class="alert-content">
      <div class="alert-body flex items-center">
        <div class="alert-icon"></div>
        <p class="p-l-16">Tên không được để trống</p>
      </div>
      <div class="mess-line"></div>
      <div class="alert-footer flex">
        <button class="m-btn" @click="onClose">Đóng</button>
      </div>
    </div>
  </div>
</template>

<script>
import { EventBus } from "../../main";

export default {
  name: "DialogConfirm",
  data() {
    return {
      isShow: false,
      alert: "",
    };
  },

  methods: {
    hideModal() {
      this.isShow = false;
    },

    onConfirm() {
      this.$emit("onConfirm");
    },

    onDelete() {
      EventBus.$emit("isConfirm");
    },
  },

  created() {
    var vm = this;
    EventBus.$on("onFilter", (data) => {
      console.log(data);
      vm.isShow = data.isShow;
      vm.alert = data.alert;
    });
  },

  beforeDestroy() {
    EventBus.$off("onFilter");
  },
};
</script>

<style>
.alert {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  max-height: 100%;
  overflow: auto;
  z-index: 10;
  display: flex;
  justify-content: center;
  align-items: center;
}

.alert .alert-content {
  position: absolute;
  width: 444px;
  height: 184px;
  background-color: azure;
  padding: 32px;
  display: flex;
  flex-direction: column;
  border-radius: 3px;
  justify-content: space-between;
}

.alert .alert-content .alert-body {
  height: 63px;
  padding-bottom: 15px;
}

.alert .alert-content .alert-body .alert-icon {
  width: 48px;
  height: 48px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -24px -954px;
}

.alert .alert-content .alert-footer {
  height: 36px;
  display: flex;
  justify-content: center;
}

.alert .alert-content .alert-footer button {
  height: 36px;
}
</style>
