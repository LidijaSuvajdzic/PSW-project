import { createRouter, createWebHistory } from "vue-router";

import StartPage from "../view/StartPage"
import StartPagePatient from "../view/patient/StartPagePatient"
import MakeAnAppointment from "../view/patient/MakeAnAppointment"
import AllAppointments from "../view/patient/AllAppointments"
import FutureAppointments from "../view/patient/FutureAppointments"
import LeaveFeedback from "../view/patient/LeaveFeedback"
import MakeAReferral from "../view/patient/MakeAReferral"
import SeeFeedback from "../view/administrator/SeeFeedback"
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
    path: "/SeeFeedback",
    name: "SeeFeedback",
    component: SeeFeedback,
  },
  {
    path: "/MakeAReferral",
    name: "MakeAReferral",
    component: MakeAReferral,
  },
  {
    path: "/LeaveFeedback",
    name: "LeaveFeedback",
    component: LeaveFeedback,
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
