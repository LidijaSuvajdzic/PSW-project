import { createRouter, createWebHistory } from "vue-router";

import StartPage from "../view/StartPage"
import StartPagePatient from "../view/patient/StartPagePatient"

const routes = [
  {
    path: "/",
    name: "StartPage",
    component: StartPage,
  },
  {
    path: "/StartPagePatient",
    name: "StartPagePatient",
    component: StartPagePatient,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
