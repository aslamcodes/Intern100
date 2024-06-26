(function () {
  const navMenus = document.getElementsByClassName("cb-c-navbar__menu__item");
  const mobileSidebarToggler = document.getElementById("js-mobile_menu");
  const menus = {};

  Array.from(navMenus).forEach((menu) => {
    menus[menu.textContent] = menu.getAttribute("href");
  });

  const sidebar = document.getElementById("js-sidebar");

  if (sidebar === null) {
    return;
  }

  // add the menus to sidebar
  for (const menu in menus) {
    const a = document.createElement("a");
    a.textContent = menu;
    a.setAttribute("href", menus[menu]);
    sidebar.appendChild(a);
  }

  mobileSidebarToggler.addEventListener("click", function () {
    sidebar.classList.toggle("open");
  });

  const sidebarClose = document.getElementById("js-sidebar-close");
  sidebarClose.addEventListener("click", function () {
    sidebar.classList.remove("open");
  });
})();
