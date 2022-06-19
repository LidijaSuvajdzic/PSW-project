import { createRouter, createWebHistory } from "vue-router";

import StartPage from "../view/StartPage"
import StartPagePatient from "../view/patient/StartPagePatient"
import MakeAnAppointment from "../view/patient/MakeAnAppointment"
import AllAppointments from "../view/patient/AllAppointments"
import FutureAppointments from "../view/patient/FutureAppointments"
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
    path: "/FutureAppointments",
    name: "FutureAppointments",
    component: FutureAppointments,
  },
  {
    path: "/MakeAnAppointment",
    name: "MakeAnAppointment",
    component: MakeAnAppointment,
  },
  {
    path: "/AllAppointments",
    name: "AllAppointments",
    component: AllAppointments,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
