let words = [
  "DWELL",
  "DWELLED",
  "DWELLING",
  "DWINDLE",
  "DWINDLED",
  "DWINDLING",
  "LEWD",
  "NEWEL",
  "WEDDED",
  "WEDDING",
  "WEDGE",
  "WEDGED",
  "WEDGIE",
  "WEDGING",
  "WEED",
  "WEEDED",
  "WEEDING",
  "WEENIE",
  "WELD",
  "WELDED",
  "WELDING",
  "WELL",
  "WELLED",
  "WELLING",
  "WEND",
  "WENDED",
  "WENDING",
  "WIDE",
  "WIDEN",
  "WIDENED",
  "WIDENING",
  "WIELD",
  "WIELDED",
  "WIELDING",
  "WIENIE",
  "WIGGED",
  "WIGGING",
  "WIGGLE",
  "WIGGLED",
  "WIGGLING",
  "WILD",
  "WILDLING",
  "WILE",
  "WILL",
  "WILLED",
  "WILLING",
  "WIND",
  "WINDED",
  "WINDING",
  "WINE",
  "WINED",
  "WING",
  "WINGDING",
  "WINGED",
  "WINGING",
  "WINING",
  "WINNING",
];

let letters = ["W", "I", "D", "E", "N", "L", "G"];

const guessed = new Set();

const lettersContainer = document.getElementById("js-letters");
const inputElement = document.getElementById("js-input");
const checkButton = document.getElementById("js-check-btn");
const deleteButton = document.getElementById("js-delete-btn");
const shuffleButton = document.getElementById("js-shuffle-btn");

function isPangram(word) {
  word = word.toUpperCase();
  let wordLetters = word.split("");
  let isPangram = true;
  letters.forEach((letter) => {
    if (!wordLetters.includes(letter)) {
      isPangram = false;
    }
  });
  return isPangram;
}

function isValidWord(word) {
  word = word.toUpperCase();
  return word.includes("W");
}

function isCorrect(word) {
  word = word.toUpperCase();
  return words.includes(word);
}

function shakeInput() {
  inputElement.classList.add("shake");
  setTimeout(() => {
    inputElement.classList.remove("shake");
  }, 500);
}

function updateGuesses() {
  const guessContainer = document.getElementById("js-guess");
  guessContainer.innerHTML = "";
  let heading = document.createElement("h2");
  heading.textContent = `Guesses ${[...guessed].length}/${words.length}`;
  guessContainer.appendChild(heading);
  guessed.forEach((guess) => {
    const guessElement = document.createElement("p");
    guessElement.textContent = guess;
    guessElement.classList.add("guess");
    guessContainer.appendChild(guessElement);
  });
}

function playSound(type) {
  var ourAudio = document.createElement("audio");
  ourAudio.style.display = "none";
  if (type === "wrong") ourAudio.src = "./assets/wrong.wav";
  else if (type === "special") ourAudio.src = "./assets/pangram.wav";
  else if (type === "correct") ourAudio.src = "./assets/correct.wav";
  ourAudio.autoplay = true;
  ourAudio.onended = function () {
    this.remove();
  };
  document.body.appendChild(ourAudio);
}

document.addEventListener("DOMContentLoaded", function () {
  letters.forEach((letter) => {
    const letterElement = document.createElement("div");
    if (letter === "W") {
      letterElement.classList.add("letter--special");
    }
    letterElement.classList.add("letter");
    letterElement.textContent = letter;
    lettersContainer.appendChild(letterElement);

    letterElement.addEventListener("click", function () {
      inputElement.value += letter;
    });
  });
});

inputElement.addEventListener("input", (e) => {
  if (!e.data) return;
  let letter = e.data.toUpperCase();
  if (!letters.includes(letter)) {
    inputElement.value = inputElement.value.slice(0, -1);
    shakeInput();
  }
});

checkButton.addEventListener("click", function () {
  const value = inputElement.value;

  if (!isValidWord(value)) {
    inputElement.value = "Invalid Word";
    playSound("wrong");
    shakeInput();
    setTimeout(() => {
      inputElement.value = "";
    }, 1000);
    return;
  }

  if (!isCorrect(value)) {
    inputElement.value = "Incorrect Word";
    playSound("wrong");
    shakeInput();
    setTimeout(() => {
      inputElement.value = "";
    }, 1000);
    return;
  }

  if (guessed.has(value)) {
    inputElement.value = "Already Guessed!";
    playSound("wrong");
    shakeInput();
    setTimeout(() => {
      inputElement.value = "";
    }, 300);
    return;
  }

  if (isPangram(value)) {
    playSound("special");
    inputElement.value = "PANGRAM!";
    guessed.add(value);
    updateGuesses();
    setTimeout(() => {
      inputElement.value = "";
    }, 1000);
    return;
  }

  inputElement.value = "Correct!";
  playSound("correct");
  setTimeout(() => {
    guessed.add(value);
    inputElement.value = "";
    updateGuesses();
  }, 500);
});

deleteButton.addEventListener("click", function () {
  inputElement.value = "";
});

shuffleButton.addEventListener("click", function () {
  let shuffledLetters = letters.sort(() => Math.random() - 0.5);
  lettersContainer.innerHTML = "";
  shuffledLetters.forEach((letter) => {
    const letterElement = document.createElement("div");
    if (letter === "W") {
      letterElement.classList.add("letter--special");
    }
    letterElement.classList.add("letter");
    letterElement.textContent = letter;
    lettersContainer.appendChild(letterElement);

    letterElement.addEventListener("click", function () {
      inputElement.value += letter;
    });
  });
});
