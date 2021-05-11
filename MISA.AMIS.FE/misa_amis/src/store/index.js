import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
  state: {
    isToggle: false,
  },
  mutations: {
    toggleSideBar(state) {
      state.isToggle = !state.isToggle;
    },
  },
  actions: {},
  modules: {},
  getters: {
    getToggle(state) {
      return state.isToggle;
    },
  },
});
export default store;
