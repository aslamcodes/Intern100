const { JSDOM } = require("jsdom");
const path = require("path");
const fs = require("fs");

test("simple button click", () => {
  let html = fs.readFileSync(path.resolve(__dirname, "../index.html"));
  let script = fs.readFileSync(path.resolve(__dirname, "../script.js"));

  const dom = new JSDOM(html, {
    runScripts: "dangerously",
    resources: "usable",
  });

  const scriptElement = dom.window.document.createElement("script");
  scriptElement.textContent = script;
  dom.window.document.body.appendChild(scriptElement);

  dom.window.document.getElementById("btn").click();
  const actual = dom.window.document.getElementById("demo").innerHTML;
  expect(actual).toBe("Hello World");
});
