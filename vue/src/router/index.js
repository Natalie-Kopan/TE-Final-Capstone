import Vue from "vue";
import Router from "vue-router";
import Home from "../views/Home.vue";
import Login from "../views/Login.vue";
import Logout from "../views/Logout.vue";
import Register from "../views/Register.vue";
import UserLibrary from "../views/UserLibrary.vue";
import FamilyDisplay from "../views/FamilyDisplay";
import PrizeDashboard from "../views/PrizeDashboard.vue";
import LibraryByUserIdView from "../views/LibraryByUserIdView.vue"
import ActivityLog from "../views/ActivityLog.vue";
import ActivityLogByUserId from "../views/ActivityLogByUserId.vue"
import PrizeDetails from "../views/PrizeDetails.vue";
import AddPrizes from "../components/AddPrizes.vue"
import ViewUserActivity from "../views/ViewUserActivity.vue";
import UserDashboard from "../views/UserDashboard.vue";
import store from "../store/index";

Vue.use(Router);

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "Home",
      component: Home,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/Dashboard",
      name: "UserDashboard",
      component: UserDashboard,
    },
    {
      path: "/login",
      name: "Login",
      component: Login,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/logout",
      name: "Logout",
      component: Logout,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/register",
      name: "Register",
      component: Register,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: '/book',
      name: 'UserLibrary',
      component: UserLibrary
    },
    {
      path: '/Family/display',
      name: 'FamilyDisplay',
      component: FamilyDisplay,
    },
    {
      path: '/ActivityLog/:isbn',
      name: 'ActivityLog',
      component: ActivityLog,
    },
    {
      path: 'ActivityLog/:isbn/:userId',
      name: 'ActivityLogByUserId',
      component: ActivityLogByUserId,
    },
    {
      path: '/Family/:userId',
      name: 'ViewUserActivity',
      component: ViewUserActivity,
    },
    {
      path: '/Prizes',
      name:'PrizeDashboard',
      component: PrizeDashboard
    },
    {
      path: '/AddPrizes',
      name:'AddPrizes',
      component: AddPrizes
    },
    {
      path: '/PrizeDetails',
      name: 'PrizeDetails',
      component: PrizeDetails,
    },
    {
      path: '/Library/:userId',
      name: 'LibraryByUserIdView',
      component: LibraryByUserIdView,
    },
    {
      path: "*",
      redirect: "/",
    },
  ],
});

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some((x) => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === "") {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
