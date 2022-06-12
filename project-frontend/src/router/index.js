import { createRouter, createWebHistory } from "vue-router";

import StartPage from "../view/StartPage"

const routes = [
  {
    path: "/",
    name: "StartPage",
    component: StartPage,
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
