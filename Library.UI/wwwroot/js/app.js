/* ==========================================================================
   Library Management System - Main JavaScript
   Only handles: sidebar toggle, mobile menu toggle,
   delete confirmation dialog, active navigation highlighting.
   Header, sidebar and footer are plain inline HTML on every page
   (no includes/partials), so this file no longer needs to fetch anything.
   ========================================================================== */

document.addEventListener("DOMContentLoaded", function () {
  highlightActiveNavItem();
  setupSidebarToggle();
  setupDeleteConfirmation();
});

/**
 * Highlights the sidebar link matching the current page's data-page
 * attribute set on <body data-page="...">.
 */
function highlightActiveNavItem() {
  var currentPage = document.body.getAttribute("data-page");
  if (!currentPage) return;

  var links = document.querySelectorAll(".app-sidebar .nav-link");
  links.forEach(function (link) {
    if (link.getAttribute("data-page") === currentPage) {
      link.classList.add("active");
    } else {
      link.classList.remove("active");
    }
  });
}

/**
 * Wires up the sidebar toggle button (desktop collapse / mobile slide-in).
 */
function setupSidebarToggle() {
  var toggleBtn = document.getElementById("sidebarToggleBtn");
  if (!toggleBtn) return;

  toggleBtn.addEventListener("click", function () {
    var isMobile = window.innerWidth <= 768;

    if (isMobile) {
      document.body.classList.toggle("sidebar-mobile-open");
    } else {
      document.body.classList.toggle("sidebar-collapsed");
    }
  });
}

/**
 * Attaches a confirmation dialog to any element with the
 * class "btn-delete" (event delegation, so it works for
 * rows rendered later too).
 */
function setupDeleteConfirmation() {
  document.addEventListener("click", function (event) {
    var deleteTrigger = event.target.closest(".btn-delete");
    if (!deleteTrigger) return;

    var itemName = deleteTrigger.getAttribute("data-name") || "this item";
    var confirmed = window.confirm(
      "Are you sure you want to delete " + itemName + "? This action cannot be undone."
    );

    if (!confirmed) {
      event.preventDefault();
    }
  });
}
