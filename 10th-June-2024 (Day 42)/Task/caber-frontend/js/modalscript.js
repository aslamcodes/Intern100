(function () {
  var body = document.querySelector("body");

  const modalWrapper = document.createElement("div");
  const modal = document.createElement("div");
  modal.classList.add("cb-c-modal");
  modalWrapper.classList.add("cb-c-modal-wrapper");

  modalWrapper.appendChild(modal);
  body.appendChild(modalWrapper);

  modalWrapper.addEventListener("click", function (e) {
    if (e.target === modalWrapper) {
      modalWrapper.classList.remove("open");

      body.style.overflow = "auto";
    }
  });

  window.toggleModal = function ({ content }) {
    modal.innerHTML = content;
    modalWrapper.classList.toggle("open");
    body.style.overflow = "hidden";
    if (modalWrapper.classList.contains("open")) {
    } else {
      body.style.overflow = "auto";
    }
  };
})();
