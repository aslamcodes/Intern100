window.getChipColorForStatus = function (status) {
  switch (status.toLowerCase()) {
    case "active":
      return "green";
    case "offline":
      return "grey";
    case "pending":
      return "yellow";
    default:
      return "green";
  }
};

window.debounce = function (func, ms) {
  let timer;
  return function () {
    clearTimeout(timer);
    timer = setTimeout(() => {
      func();
    }, ms);
  };
};
