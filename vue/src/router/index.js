import Vue from "vue";
import Router from "vue-router";
import Home from "../views/Home.vue";
import Login from "../views/Login.vue";
import Logout from "../views/Logout.vue";
import Register from "../views/Register.vue";
import AddBook from "../views/AddBook.vue";
import UserLibrary from "../views/UserLibrary.vue";
import FamilyAdd from "../views/FamilyAdd.vue";
import FamilyDisplay from "../views/FamilyDisplay";
import Prizes from "../views/Prizes.vue";
import ViewPrizes from "../views/ViewPrizes.vue";
import ActivityLog from "../views/ActivityLog.vue";
import PrizeDetails from "../views/PrizeDetails.vue";
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
      name: 'AddBook',
      component: AddBook,
    },
    {
      path: '/book',
      name: 'UserLibrary',
      component: UserLibrary
    },
    {
      path: '/Family/add',
      name: 'FamilyAdd',
      component: FamilyAdd,
    },
    {
      path: '/Family/display',
      name: 'FamilyDisplay',
      component: FamilyDisplay,
    },
    {
      path: '/Prizes',
      name: 'Prizes',
      component: Prizes,
    },
    {
      path: '/ActivityLog/:isbn',
      name: 'ActivityLog',
      component: ActivityLog,
    },
    {
      path: '/Family/:userId',
      name: 'ViewUserActivity',
      component: ViewUserActivity,
    },
    {
      path: '/Prizes',
      name: 'ViewPrizes',
      component: ViewPrizes,
    },
    {
      path: '/Prizes',
      name:'PrizeDetails',
      component: PrizeDetails
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
