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
            border-radius: 2px;
            padding: 16px;
            font-size: 17px;
            opacity: 0;
            transition: opacity 0.5s, bottom 0.5s;
            position: relative;
            visibility: hidden;
        }
        .toast.show {
            visibility: visible;
            opacity: 1;
        }
        .toast.success {
            background-color: #4CAF50;
            color: #fff;
        }
        .toast.info {
            background-color: #2196F3;
            color: #fff;
        }
        .toast.error {
            background-color: #f44336;
            color: #fff;
        }
        .toast.warning {
            background-color: #ff9800;
            color: #fff;
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
