(function () {
  var styles = `
        .toast-container {
            position: fixed;
            z-index: 1;
            left: 50%;
            bottom: 30px;
            transform: translateX(-50%);
            display: flex;
            flex-direction: column;
            align-items: center;
        }
        .toast {
            min-width: 250px;
            margin: 10px 0;
            text-align: center;
            border-radius: 8px;
            padding: 16px;
            font-size: 17px;
            opacity: 0;
            transition: opacity 0.5s, bottom 0.5s;
            position: relative;
            visibility: hidden;
            // transparent
            background-color: rgba(0, 0, 0, 0.5);
            backdrop-filter: blur(10px);
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            opacity: 0;

        }
        .toast.show {
            visibility: visible;
            opacity: 1;
        }
        .toast.success {
        background-color: rgba(0, 255, 0, 0.5);
        }
        .toast.info {
        background-color: rgba(0, 0, 255, 0.5);
        color: white;
        }
        .toast.error {
        background-color: rgba(255, 0, 0, 0.2);
        }
        .toast.warning {
        }
    `;

  var styleSheet = document.createElement("style");
  styleSheet.type = "text/css";
  styleSheet.innerText = styles;
  document.head.appendChild(styleSheet);

  var toastContainer = document.createElement("div");
  toastContainer.className = "toast-container";
  document.body.appendChild(toastContainer);

  window.showToast = function (
    message,
    type = "success",
    duration = 3000,
    callback
  ) {
    var toast = document.createElement("div");
    toast.className = `toast ${type}`;
    toast.textContent = message;
    toastContainer.appendChild(toast);

    setTimeout(() => {
      toast.className += " show";
    }, 10);

    setTimeout(function () {
      toast.className = toast.className.replace(" show", "");
      setTimeout(function () {
        toastContainer.removeChild(toast);
        if (callback) {
          callback();
        }
      }, 500);
    }, duration);
  };
})();
