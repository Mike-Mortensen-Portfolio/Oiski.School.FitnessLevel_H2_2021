using System;

namespace Oiski.School.FitnessLevel_H2_2021.Application
{
    class Program
    {
        static void Main (string[] args)
        {
            int menuIndex = 0;
            do
            {
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
                        #endregion

                        #region Result menu
                        #endregion
                }
            } while ( true );
        }
    }
}
