using System;

namespace guess_the_number
{
    class Program
    {
        static bool loop = false;
        static int userGuess;
        static int numberOfTries;
        static int RandomizeNr()
        {
            Random rnd = new Random();
            int randomNr = rnd.Next(1, 101);
            return randomNr;
        }

        static void GuessTheNumber(int secretNr)
        {
            numberOfTries = 0;
            do
            {
                do
                {

                    loop = false;
                    try
                    {
                        Console.Write("Vilket tal är rätt? ");
                        userGuess = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        loop = true;
                        Console.WriteLine("Endast heltal!");
                    }
                }
                while (loop);

                if (userGuess > secretNr)
                {
                    Console.WriteLine("Det hemliga talet är mindre!");
                    numberOfTries++;
                }
                else if (userGuess < secretNr)
                {
                    Console.WriteLine("Det hemliga talet är större");
                    numberOfTries++;
                }
                else
                {
                    numberOfTries++;
                    Console.WriteLine("Grattis!!!!!!!! Du har gissat rätt tal!");
                    Console.WriteLine("Det tog dig " + numberOfTries + " att gissa rätt tal!");
                }
            }
            while (secretNr != userGuess);
        }

        static bool WannaPlayAgain()
        {
            do
            {
                loop = false;

                try
                {
                    Console.WriteLine("Vill du spela igen? [Ja/Nej]");
                    string yesOrNo = Console.ReadLine().ToUpper();
                    if (yesOrNo[0] == 'J')
                    {
                        return true;
                    }
                    else if (yesOrNo[0] == 'N')
                    {
                        Console.WriteLine("Spelet avslutas..");
                        Console.ReadKey();
                        return false;
                    }
                    else
                    {
                        loop = true;
                        Console.WriteLine("Ja eller nej tack!");
                    }
                }
                catch
                {
                    Console.WriteLine("Ja eller nej tack!");
                }
            } while (loop);
            return false;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Spelet tänker på ett tal mellan 1-100. Gissa vilket!");
                int secretNr = RandomizeNr();
                GuessTheNumber(secretNr);
                loop = WannaPlayAgain();
            }
            while (loop);
        }
    }
}
