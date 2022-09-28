using System.Collections;

namespace PrimeNumberChallenge; 
public class Program {

    public static void Main(string[] args) {
        string? looping;

        do {
            Console.WriteLine("What number do you want to check for prime: ");
            var numToCheckText = Console.ReadLine();

            if (numToCheckText != null) {
                int numToCheck = int.Parse(numToCheckText);
                bool isPrime = IsPrime(numToCheck);

                if (isPrime) {
                    Console.WriteLine($"{numToCheck} is prime.");
                } else {
                    Console.WriteLine($"{numToCheck} is a composite number.");
                    var factors = CalculateFactors(numToCheck);

                    if(factors.Count > 0) {
                        Console.Write($"Factors of {numToCheck} are: ");
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

            Console.WriteLine();
            Console.WriteLine("Do you want to continue (yes/no): ");
            looping = Console.ReadLine();


        } while (looping.ToLower() == "yes" || looping.ToLower() == "y");

        Console.WriteLine(IsPrime(Convert.ToInt16(Console.ReadLine())));
    }

    static ArrayList CalculateFactors(int num) {
        ArrayList factors = new ArrayList();

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

        // looks like we can take 1/2 the num
        int numToCheck = num / 2;
        
        for (int i = numToCheck; i > 0; i--) {
            int counter = 1;

            for (int j = 1; j < numToCheck; j++) {
                if(i * counter == num) {
                    factors.Add(i);
                }

                counter++;
            }
        }

        return factors;
    }

    static bool IsPrime(int num) {
        bool isPrime = true;
        int max = num / 2;

        // 7  
        // 8 - 2,3,4,5,6,7

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