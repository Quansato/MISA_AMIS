import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

//Views
import Employee from "../views/dictionary/Employee";
//import Pagination from '../components/pagination/Pagination'
//import DialogConfirm from "../components/Dialog/DialogConfirm";
//import AppLayout from '@/layouts/AppLayout'

const routes = [
  {
    path: "/Employee",
    name: "Employee",
    component: Employee,
  },
  // {
  //   path: "/Pagination",
  //   name: "DialogConfirm",
  //   component: DialogConfirm,
  // },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
