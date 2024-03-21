using System;
using System.Collections.Generic;

class InfixToPostfixConverter
{
    static int Precedence(char op) => op switch
    {
        '+' or '-' => 1,
        '*' or '/' => 2,
        '^' => 3,
        _ => -1
    };

    static bool IsOperator(char c) => c == '+' || c == '-' || c == '*' || c == '/' || c == '^';

    static string ConvertToPostfix(string infix)
    {
        Stack<char> stack = new();
        string postfix = "";

        foreach (char c in infix)
        {
            if (char.IsLetterOrDigit(c))
            {
                postfix += c;
            }
            else if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    postfix += stack.Pop();
                }

                if (stack.Count > 0 && stack.Peek() != '(')
                {
                    return "Geçersiz İfade";
                }
                else
                {
                    stack.Pop();
                }
            }
            else
            {
                while (stack.Count > 0 && Precedence(c) <= Precedence(stack.Peek()))
                {
                    postfix += stack.Pop();
                }
                stack.Push(c);
            }
        }

        while (stack.Count > 0)
        {
            postfix += stack.Pop();
        }

        return postfix;
    }

    static void Main()
    {
        string infixExpression = "A+B+D*F-(G/H+J)*K";
        string postfixExpression = ConvertToPostfix(infixExpression);
        Console.WriteLine("Infix ifade: " + infixExpression);
        Console.WriteLine("Postfix ifade: " + postfixExpression);
    }
}
