import { createRouter, createWebHistory } from "vue-router";

import StartPage from "../view/StartPage"
import StartPagePatient from "../view/patient/StartPagePatient"
import MakeAnAppointment from "../view/patient/MakeAnAppointment"
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
  {
    path: "/MakeAnAppointment",
    name: "MakeAnAppointment",
    component: MakeAnAppointment,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
