using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGameLibrary
{
    public class HangmanGameWithUndo : HangmanGame
    {
        public HangmanMemento CreateSetPoint()
        {
            var guesses = PreviousGuesses.ToArray();
            return new HangmanMemento() { Guessses = guesses };
        }

        public void ResumeFrom(HangmanMemento memento)
        {
            var guesses = memento.Guessses;
            PreviousGuesses.Clear();
            PreviousGuesses.AddRange(guesses);
        }
    }
}
