def greet(name, gender):
    salutation = ''
    if(gender.lower() == 'm'):
        salutation = "Mr."
    else:
        salutation = "Ms."

    print("Hey There!", salutation, name, sep=" ")

if __name__ == "__main__":
    name = input("Give us your name")
    gender = input("Pleave provide your gender (M/F)")
    greet(name, gender)