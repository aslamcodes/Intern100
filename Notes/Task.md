Quiz Creation Application

Objective:
Develop a console-based quiz creation application to allow users to create, manage, and take quizzes on various topics.

Functional Requirements:


- [x] **Quiz Creation:**
   - [x] Enable users to create quizzes by providing a title, description, and a set of questions with multiple-choice answers.
   - [x] Each question should have one correct answer and may have multiple incorrect answers.

2. **Quiz Management:**
   - [x] Allow quiz creators(all users) to ~~edit, delete~~, or publish their quizzes.
   - [x] Published quizzes should be available for other users to take.

3. **Quiz Taking:**
   - [x] Allow users to browse and select quizzes from the available list of published quizzes.
   - [x] Present one question at a time during the quiz taking process.
   - [x] Calculate and display the final score at the end of the quiz.

4. **Quiz Review:**
   - [x] Allow users to review their last quiz attempt, showing which questions were answered correctly and incorrectly.
   - [x] Display the correct answers for incorrectly answered questions.


Non-Functional Requirements:

1. **User Interface:**
   - Design a user-friendly console interface with clear menus and prompts for easy navigation and interaction.

2. **Efficiency:**
   - Ensure efficient processing of quiz creation, management, and taking operations, even with a large number of users and quizzes.

3. **Security:**
   - Implement authentication and authorization mechanisms to ensure that only registered users can create, edit, or delete quizzes.

4. **Scalability:**
   - Design the application to handle a growing number of users, quizzes, and quiz attempts without performance degradation.

Optional Enhancements (Not required but could be added for further functionality):

1. **Randomized Questions:**
   - Implement the option to randomize the order of questions during quiz taking to prevent memorization.

2. **Categories and Tags:**
   - Allow quiz creators to categorize their quizzes and add tags to facilitate easy searching and filtering.

![[Pasted image 20240422151424.png]]]]