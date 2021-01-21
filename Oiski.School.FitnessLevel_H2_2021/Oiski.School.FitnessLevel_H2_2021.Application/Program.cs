using System;

namespace Oiski.School.FitnessLevel_H2_2021.Application
{
    class Program
    {
        static void Main (string[] args)
        {
            FitnessCalc fitness = new FitnessCalc();
            int menuIndex = 0;
            do
            {
                Console.Clear();
                switch ( menuIndex )
                {
                    #region Main Menu
                    case 0:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1) Data Collection");
                            Console.WriteLine("2) Results");
                        } while ( !int.TryParse(Console.ReadLine(), out menuIndex) && menuIndex > 0 && menuIndex < 3 );
                        break;
                    #endregion

                    #region Data Menu
                    case 1:

                        decimal weight;
                        int restingHeartRate;
                        int maxHeartRate;

                        do
                        {
                            Console.Write("Enter Weight (kg): ");
                        } while ( !decimal.TryParse(Console.ReadLine(), out weight) );

                        do
                        {
                            Console.Write("Enter Resting Heart Rate (BPM): ");
                        } while ( !int.TryParse(Console.ReadLine(), out restingHeartRate) );

                        do
                        {
                            Console.Write("Enter Max Heart Rate (BPM): ");
                        } while ( !int.TryParse(Console.ReadLine(), out maxHeartRate) );

                        fitness.Weight = weight;
                        fitness.RestingHeartRate = restingHeartRate;
                        fitness.MaxHeartRate = maxHeartRate;

                        Console.WriteLine("Press Any Key...");
                        Console.Read();
                        menuIndex = 0;
                        break;
                    #endregion

                    #region Result Menu
                    case 2:
                        Console.WriteLine($"Weight: {fitness.Weight}kg");
                        Console.WriteLine($"Resting Heart Rate: {fitness.RestingHeartRate} BPM");
                        Console.WriteLine($"Max Heart Rate: {fitness.MaxHeartRate} BPM");
                        Console.WriteLine($"Fitness Level: {fitness.GetFitnessLevel()} ml/kg/min");
                        Console.WriteLine($"VO2 Max Score: {fitness.GetVO2Max()} l/ml");
                        Console.WriteLine();

                        Console.WriteLine("Press Any Key...");
                        Console.Read();
                        menuIndex = 0;
                        break;
                        #endregion 
                }
            } while ( true );
        }
    }
}
