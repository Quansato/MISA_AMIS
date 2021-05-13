import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
  state: {
    isToggle: false,
    isShowDialogEmployee:false
  },
  mutations: {
    toggleSideBar(state) {
      state.isToggle = !state.isToggle;
    },

    toggleDialog(state){
      state.isShowDialogEmployee=!state.isShowDialogEmployee
    }
  },
  actions: {},
  modules: {},
  getters: {
    getToggle(state) {
      return state.isToggle;
    },

    getIsShow(state) {
      return state.isShowDialogEmployee;
    },
  },
});
export default store;
