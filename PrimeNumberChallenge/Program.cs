namespace PrimeNumberChallenge;
public class Program {

    public static void Main(string[] args) {
        string? looping;

        do {
            DisplayMessage(("What number do you want to check for prime: "));
            var numToCheckText = Console.ReadLine();

            if (numToCheckText != null) {
                int numToCheck = int.Parse(numToCheckText);
                bool isPrime = IsPrime(numToCheck);

                if (isPrime) {
                    DisplayMessage($"{numToCheck} is prime.");
                } else {
                    DisplayMessage($"{numToCheck} is a composite number.");
                    var factors = CalculateFactors(numToCheck);

                    if(factors.Count > 0) {
                        DisplayMessage($"The largest prime factor is {factors.Max()}");
                        DisplayMessage($"Factors of {numToCheck} are: ");
                        int i = 0;
                        foreach (var item in factors) {
                            if (i < (factors.Count - 1)) {
                                Console.Write($"{item}, ");
                            } else {
                                Console.Write($"{item}");
                            }

                            i++;
                        }
                    }
                }
            }

            DisplayMessage("");
            DisplayMessage("Do you want to continue (yes/no): ");
            looping = Console.ReadLine();

        } while (looping.ToLower() == "yes" || looping.ToLower() == "y");

        DisplayMessage(IsPrime(Convert.ToInt16(Console.ReadLine())).ToString());
    }

    static void DisplayMessage(string message) => Console.WriteLine(message);

    static List<int> CalculateFactors(int num) {
        List<int> factors = new List<int>();

        // 24
        // 2 x 12
        // 3 x 8
        // 4 x 6
        // 5 !=
        // 6 x 4
        // 7 !=
        // 8 x 3
        // 9 != 
        // 10 != 
        // 11 !=
        // 12 x 2

        for(int i = 2; i <= num; i++) {
            if(num % i == 0 && i != num) {
                factors.Add(i);
            }
        }
        
        return factors;
    }

    static bool IsPrime(int num) {
        bool isPrime = true;
        int max = num / 2;

        // 24
        // 24 / 2 = 12
        // max == 12
        // 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
        // prime numbers of 24
        // 2, 3, 4, 6, 8, 12

        // starting iterator at 2 because 1 is not considered a prime number
        for (int i = 2; i < max; i++) {
            if (num % i == 0) {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }
}