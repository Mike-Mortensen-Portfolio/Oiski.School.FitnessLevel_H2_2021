using System;
using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Rendering;

namespace Oiski.School.FitnessLevel_H2_2021.Application
{
    class Program
    {
        static void Main (string[] args)
        {
            #region Engine Setup
            Console.SetWindowSize(60, 30);
            ColorRenderer renderer = new ColorRenderer();
            renderer.DefaultColor = new RenderColor(ConsoleColor.Red, ConsoleColor.Black);

            OiskiEngine.ChangeRenderer(renderer);
            OiskiEngine.Run();
            #endregion

            RenderColor textColor = new RenderColor(ConsoleColor.Cyan, ConsoleColor.Black);
            RenderColor borderColor = new RenderColor(ConsoleColor.DarkBlue, ConsoleColor.Black);

            FitnessCalc fitness = new FitnessCalc();

            #region Main Menu
            #endregion

            #region Data Menu
            #endregion

            #region Result Menu
            #endregion
        }
    }
}
