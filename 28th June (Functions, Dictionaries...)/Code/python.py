import random
# cow and bull game with words

def cow_and_bull_game():
    words = [
        "banana",
        "cherry",
        "grapes",
        "python",
        "jacket",
        "rocket",
    ]

    word = random.choice(words)

    print("Welcome to the Cows and Bulls Game!")

    print("Enter a 6 lettered word:")
    
    while True:
        lifes = 6

        if lifes == 0:
            print("You lost!")
            break

        guess = input()
        lifes -= 1

        if len(guess) != 6:
            print("Enter a 6 lettered word:")
            continue

        if guess == word:
            print("You win!")
            break
        cows = 0
        bulls = 0
        for i in range(len(word)):
            if guess[i] == word[i]:
                cows += 1
                print("cow - ", guess[i])
            elif guess[i] in word:
                bulls += 1
                print("bull - ", guess[i])

        print(f"{cows} cows, {bulls} bulls")

cow_and_bull_game()