using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HangmanGameLibrary
{
    public class HangmanGame
    {
        private readonly string secretWord;
        private const char maskChar = '_';
        protected const int INITIAL_GUESSES = 5;

        public HangmanGame()
        {
            string[] secretWords = { "Audacious", "Lull", "Antagonize", "Remember" };
            this.secretWord = secretWords[new Random().Next(4)].ToUpperInvariant();
        }

        public GameResult Result { get; private set; }
        public bool IsOver => Result > GameResult.InProgress;
        public List<char> PreviousGuesses { get; } = new List<char>();
        public string CurrentMaskedWord => new string(secretWord.Select(c => PreviousGuesses.Contains(c) ? c : maskChar).ToArray());
        public int GuessesRemaining => INITIAL_GUESSES - PreviousGuesses.Count(c => !CurrentMaskedWord.Contains(c));

        public void Guess(char guessChar)
        {
            // TODO: Consider using Ardalis.GuardClauses
            // TODO: Consider resturning Ardalis.Result
            if (char.IsWhiteSpace(guessChar)) throw new InvalidGuessException("Guess cannot be blank.");
            if (!Regex.IsMatch(guessChar.ToString(), "^[A-Z]$")) throw new InvalidGuessException("Guess must be a capital letter A through Z");
            if (IsOver) throw new InvalidGuessException("Can't make guesses after game is over.");
            if (PreviousGuesses.Any(g => g == guessChar)) throw new DuplicateGuessException();

            PreviousGuesses.Add(guessChar);
            if(secretWord.IndexOf(guessChar) >= 0)
            {
                if (!CurrentMaskedWord.Contains(maskChar))
                {
                    Result = GameResult.Won;
                }
                return;
            }

            if(GuessesRemaining <= 0)
            {
                Result = GameResult.Lost;
            }
        }
    }
}
