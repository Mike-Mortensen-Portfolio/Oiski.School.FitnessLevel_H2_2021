using System;
using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;

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

            Menu mainMenu = new Menu();
            Menu dataMenu = new Menu();
            Menu resultMenu = new Menu();

            #region Main Menu

            #region Header
            ColorableLabel mainHeader = new ColorableLabel("Oiski's Fitness Calculator", textColor, borderColor, _attachToEngine: false);
            mainHeader.Position = new Vector2(Vector2.CenterX(mainHeader.Size.x), 5);

            mainMenu.Controls.AddControl(mainHeader);
            #endregion

            #region Data Menu Button
            ColorableOption toDataMenu = new ColorableOption("Data Collection", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = Vector2.Zero
            };
            toDataMenu.Position = new Vector2(Vector2.CenterX(toDataMenu.Size.x), mainHeader.Position.y + 6);
            toDataMenu.BorderStyle(BorderArea.Horizontal, '~');

            toDataMenu.OnSelect += (s) =>
            {
                #region Hide Main Menu
                OiskiEngine.Input.ResetInput();
                OiskiEngine.Input.ResetSlection();

                mainMenu.Show(false);
                #endregion

                //  Show Data Menu
            };

            mainMenu.Controls.AddControl(toDataMenu);
            #endregion

            #region Result Menu Button
            ColorableOption toResultMenu = new ColorableOption("Results", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 1)
            };
            toResultMenu.Position = new Vector2(Vector2.CenterX(toResultMenu.Size.x), toDataMenu.Position.y + 3);

            toResultMenu.OnSelect += (s) =>
            {
                #region Hide Main Menu
                OiskiEngine.Input.ResetInput();
                OiskiEngine.Input.ResetSlection();

                mainMenu.Show(false);
                #endregion

                //  Show Result Menu
            };

            mainMenu.Controls.AddControl(toResultMenu);
            #endregion

            #region Exit Button
            ColorableOption exitButton = new ColorableOption("Exit ", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 2)
            };
            exitButton.Position = new Vector2(Vector2.CenterX(exitButton.Size.x), toResultMenu.Position.y + 3);

            exitButton.OnSelect += (s) =>
            {
                Environment.Exit(0);
            };

            mainMenu.Controls.AddControl(exitButton);
            #endregion

            mainMenu.Show();
            #endregion

            #region Data Menu
            #endregion

            #region Result Menu
            #endregion
        }
    }
}
