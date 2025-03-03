using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text mathProblemText; // Text to display the math problem
    public TMP_InputField answerInputField; // Input field for the player's answer

    private int correctAnswer; // Stores the correct answer

    void Start()
    {
        // Generate the first math problem
        GenerateMathProblem();  

        // Add a listener to the input field to detect the Enter key
        answerInputField.onSubmit.AddListener(OnInputSubmit);
    }

    void GenerateMathProblem()
    {
        // Randomly choose an operation (0: addition, 1: subtraction, 2: multiplication, 3: division)
        int operation = Random.Range(0, 4);

        int num1, num2;
        string problem = "";

        switch (operation)
        {
            case 0: // Addition
                num1 = Random.Range(1, 100);
                num2 = Random.Range(1, 100);
                correctAnswer = num1 + num2;
                problem = $"{num1} + {num2} = ";
                break;

            case 1: // Subtraction
                num1 = Random.Range(1, 100);
                num2 = Random.Range(1, num1); // Ensure num2 is less than num1 to avoid negative answers
                correctAnswer = num1 - num2;
                problem = $"{num1} - {num2} = ";
                break;

            case 2: // Multiplication
                num1 = Random.Range(1, 20);
                num2 = Random.Range(1, 20);
                correctAnswer = num1 * num2;
                problem = $"{num1} × {num2} = ";
                break;

            case 3: // Division
                num2 = Random.Range(1, 20);
                correctAnswer = Random.Range(1, 20);
                num1 = num2 * correctAnswer; // Ensure the division results in a whole number
                problem = $"{num1} ÷ {num2} = ";
                break;
        }

        // Display the problem
        mathProblemText.text = problem;

        // Clear the input field
        answerInputField.text = "";

        // Focus on the input field for the player to type immediately
        answerInputField.ActivateInputField();
    }

    void CheckAnswer()
    {
        // Get the player's input
        if (int.TryParse(answerInputField.text, out int playerAnswer))
        {
            // Check if the answer is correct
            if (playerAnswer == correctAnswer)
            {
                Debug.Log("Correct!");
                // Generate a new problem
                GenerateMathProblem();
            }
            else
            {
                Debug.Log("Incorrect. Try again!");
            }
        }
        else
        {
            Debug.Log("Invalid input. Please enter a whole number.");
        }
    }

    // This method is called when the player presses Enter in the input field
    void OnInputSubmit(string input)
    {
        CheckAnswer();
    }
}