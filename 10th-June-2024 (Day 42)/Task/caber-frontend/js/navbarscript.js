(function () {
  document.addEventListener("DOMContentLoaded", function () {
    const navMenus = document.getElementsByClassName("cb-c-navbar__menu__item");
    const mobileSidebarToggler = document.getElementById("js-mobile_menu");
    const menus = {};
    const currentRole = localStorage.getItem("role");

    Array.from(navMenus)
      .filter((menu) => {
        if (currentRole === "Driver") {
          return menu.classList.contains("js-driver-role");
        } else if (currentRole === "Passenger") {
          return menu.classList.contains("js-passenger-role");
        } else if (currentRole === "Admin") {
          return menu.classList.contains("js-admin-role");
        }

        return true;
      })
      .forEach((menu) => {
        menus[menu.textContent] = menu.getAttribute("href");
      });

    // Array.from(navMenus).forEach((menu) => {
    //   if (
    //     menu.classList.contains("js-driver-role") &&
    //     currentRole === "Driver"
    //   ) {
    //     menus[menu.textContent] = menu.getAttribute("href");
    //   } else if (
    //     menu.classList.contains("js-passenger-role") &&
    //     currentRole === "Passenger"
    //   ) {
    //     menus[menu.textContent] = menu.getAttribute("href");
    //   } else if (
    //     !menu.classList.contains("js-driver-role") &&
    //     !menu.classList.contains("js-passenger-role")
    //   ) {
    //     menus[menu.textContent] = menu.getAttribute("href");
    //   }
    // });

    const sidebar = document.getElementById("js-sidebar");

    if (sidebar === null) {
      console.warn("No Sidebar");
      return;
    }

    // add the menus to sidebar
    for (const menu in menus) {
      const a = document.createElement("a");
      a.textContent = menu;
      a.setAttribute("href", menus[menu] ?? "#");
      sidebar.appendChild(a);
    }

    mobileSidebarToggler.addEventListener("click", function () {
      sidebar.classList.toggle("open");
    });

    const sidebarClose = document.getElementById("js-sidebar-close");
    sidebarClose.addEventListener("click", function () {
      sidebar.classList.remove("open");
    });
  });
})();
