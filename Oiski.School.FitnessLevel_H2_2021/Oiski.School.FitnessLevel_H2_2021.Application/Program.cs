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
                s.BorderStyle(BorderArea.Horizontal, '-');

                mainMenu.Show(false);
                #endregion

                dataMenu.Controls.GetSelectableControls[0].BorderStyle(BorderArea.Horizontal, '~');
                dataMenu.Show();
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
                s.BorderStyle(BorderArea.Horizontal, '-');

                mainMenu.Show(false);
                #endregion

                resultMenu.Controls.GetSelectableControls[0].BorderStyle(BorderArea.Horizontal, '~');
                resultMenu.Show();
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

            #region Header
            ColorableLabel dataHeader = new ColorableLabel("Oiski's Data", textColor, borderColor, _attachToEngine: false);
            dataHeader.Position = new Vector2(Vector2.CenterX(dataHeader.Size.x), 5);

            dataMenu.Controls.AddControl(dataHeader);
            #endregion

            #region Weight
            decimal weight = 0;

            ColorableLabel weightLabel = new ColorableLabel("Weight", textColor, borderColor, _attachToEngine: false);
            weightLabel.Position = new Vector2(15, dataHeader.Position.y + 6);

            dataMenu.Controls.AddControl(weightLabel);

            ColorableTextField weightText = new ColorableTextField("Type Weight...", new RenderColor(ConsoleColor.Green, ConsoleColor.Black), borderColor, _attachToEngine: false)
            {
                SelectedIndex = Vector2.Zero,
                ResetAfterFirstWrite = false,
                EraseTextOnSelect = true
            };
            weightText.Position = new Vector2(weightLabel.Position.x + weightLabel.Size.x - 1, weightLabel.Position.y);
            weightText.BorderStyle(BorderArea.Horizontal, '~');

            weightText.OnSelect += (s) =>
            {
                if ( !OiskiEngine.Input.CanWrite )
                {
                    if ( !decimal.TryParse(weightText.Text, out weight) )
                    {
                        weightText.TextColor = new RenderColor(ConsoleColor.Red, ConsoleColor.Black);
                        weightText.Text = "Invalid Input";
                    }

                }
                else
                {
                    weightText.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);
                }
            };

            dataMenu.Controls.AddControl(weightText);
            #endregion

            #region Resting Heart Rate
            int restingHeartRate = 0;

            ColorableLabel restingHeartRateLabel = new ColorableLabel("R-Heart Rate (BPM)", textColor, borderColor, _attachToEngine: false);
            restingHeartRateLabel.Position = new Vector2(15, weightLabel.Position.y + 3);

            dataMenu.Controls.AddControl(restingHeartRateLabel);

            ColorableTextField restingHeartRateText = new ColorableTextField("Type Rate...", new RenderColor(ConsoleColor.Green, ConsoleColor.Black), borderColor, _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 1),
                ResetAfterFirstWrite = false,
                EraseTextOnSelect = true
            };
            restingHeartRateText.Position = new Vector2(restingHeartRateLabel.Position.x + restingHeartRateLabel.Size.x - 1, restingHeartRateLabel.Position.y);

            restingHeartRateText.OnSelect += (s) =>
            {
                if ( !OiskiEngine.Input.CanWrite )
                {
                    if ( !int.TryParse(restingHeartRateText.Text, out restingHeartRate) )
                    {
                        restingHeartRateText.TextColor = new RenderColor(ConsoleColor.Red, ConsoleColor.Black);
                        restingHeartRateText.Text = "Invalid Input";
                    }

                }
                else
                {
                    restingHeartRateText.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);
                }
            };

            dataMenu.Controls.AddControl(restingHeartRateText);
            #endregion

            #region Max Heart Rate
            int maxHeartRate = 0;

            ColorableLabel maxHeartRateLabel = new ColorableLabel("M-Heart Rate (BPM)", textColor, borderColor, _attachToEngine: false);
            maxHeartRateLabel.Position = new Vector2(15, restingHeartRateLabel.Position.y + 3);

            dataMenu.Controls.AddControl(maxHeartRateLabel);

            ColorableTextField maxHeartRateText = new ColorableTextField("Type Rate...", new RenderColor(ConsoleColor.Green, ConsoleColor.Black), borderColor, _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 2),
                ResetAfterFirstWrite = false,
                EraseTextOnSelect = true
            };
            maxHeartRateText.Position = new Vector2(maxHeartRateLabel.Position.x + maxHeartRateLabel.Size.x - 1, maxHeartRateLabel.Position.y);

            maxHeartRateText.OnSelect += (s) =>
            {
                if ( !OiskiEngine.Input.CanWrite )
                {
                    if ( !int.TryParse(maxHeartRateText.Text, out maxHeartRate) )
                    {
                        maxHeartRateText.TextColor = new RenderColor(ConsoleColor.Red, ConsoleColor.Black);
                        maxHeartRateText.Text = "Invalid Input";
                    }

                }
                else
                {
                    maxHeartRateText.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);
                }
            };

            dataMenu.Controls.AddControl(maxHeartRateText);
            #endregion

            #region Back Button
            ColorableOption dataMenuBackButton = new ColorableOption("Back ", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = new Vector2(0, 3)
            };
            dataMenuBackButton.Position = new Vector2(Vector2.CenterX(dataMenuBackButton.Size.x), maxHeartRateLabel.Position.y + 3);

            dataMenuBackButton.OnSelect += (s) =>
            {
                #region Hide Data Menu
                OiskiEngine.Input.ResetInput();
                OiskiEngine.Input.ResetSlection();
                s.BorderStyle(BorderArea.Horizontal, '-');

                dataMenu.Show(false);
                #endregion

                fitness.Weight = weight;
                fitness.RestingHeartRate = restingHeartRate;
                fitness.MaxHeartRate = maxHeartRate;

                mainMenu.Controls.GetSelectableControls[0].BorderStyle(BorderArea.Horizontal, '~');
                mainMenu.Show();
            };

            dataMenu.Controls.AddControl(dataMenuBackButton);
            #endregion

            #endregion

            #region Result Menu

            #region Header
            ColorableLabel resultHeader = new ColorableLabel("Oiski's Results", textColor, borderColor, _attachToEngine: false);
            resultHeader.Position = new Vector2(Vector2.CenterX(resultHeader.Size.x), 5);

            resultMenu.Controls.AddControl(resultHeader);
            #endregion

            #region Weight
            ColorableLabel weightResultLabel = new ColorableLabel("Weight (kg)", textColor, borderColor, _attachToEngine: false);
            weightResultLabel.Position = new Vector2(10, resultHeader.Position.y + 5);

            resultMenu.Controls.AddControl(weightResultLabel);

            ColorableLabel weightResultText = new ColorableLabel(fitness.Weight.ToString(), new RenderColor(ConsoleColor.Green, ConsoleColor.Black), borderColor, _attachToEngine: false);
            weightResultText.Position = new Vector2(weightResultLabel.Position.x + weightResultLabel.Size.x - 1, weightResultLabel.Position.y);

            weightResultText.OnUpdate += (c) =>
            {
                weightResultText.Text = fitness.Weight.ToString();
            };

            resultMenu.Controls.AddControl(weightResultText);
            #endregion

            #region Resting Heart Rate
            ColorableLabel restingHeartRateResultLabel = new ColorableLabel("R-Heart Rate (BPM)", textColor, borderColor, _attachToEngine: false);
            int positionX = weightResultLabel.Position.x + weightResultLabel.Size.x + weightResultText.Size.x + 2;
            restingHeartRateResultLabel.Position = new Vector2(positionX, weightResultLabel.Position.y);

            resultMenu.Controls.AddControl(restingHeartRateResultLabel);

            ColorableLabel restingHeartRateResultText = new ColorableLabel(fitness.RestingHeartRate.ToString(), new RenderColor(ConsoleColor.Green, ConsoleColor.Black), borderColor, _attachToEngine: false);
            restingHeartRateResultText.Position = new Vector2(restingHeartRateResultLabel.Position.x + restingHeartRateResultLabel.Size.x - 1, restingHeartRateResultLabel.Position.y);

            restingHeartRateResultText.OnUpdate += (c) =>
            {
                restingHeartRateResultText.Text = fitness.RestingHeartRate.ToString();
            };

            resultMenu.Controls.AddControl(restingHeartRateResultText);
            #endregion

            #region Max Heart Rate
            ColorableLabel maxHeartRateResultLabel = new ColorableLabel("M-Heart Rate (BPM)", textColor, borderColor, _attachToEngine: false);
            maxHeartRateResultLabel.Position = new Vector2(weightResultLabel.Position.x, weightResultLabel.Position.y + 3);

            resultMenu.Controls.AddControl(maxHeartRateResultLabel);

            ColorableLabel maxHeartRateResultText = new ColorableLabel(fitness.MaxHeartRate.ToString(), new RenderColor(ConsoleColor.Green, ConsoleColor.Black), borderColor, _attachToEngine: false);
            maxHeartRateResultText.Position = new Vector2(maxHeartRateResultLabel.Position.x + maxHeartRateResultLabel.Size.x - 1, maxHeartRateResultLabel.Position.y);

            maxHeartRateResultText.OnUpdate += (c) =>
            {
                maxHeartRateResultText.Text = fitness.MaxHeartRate.ToString();
            };

            resultMenu.Controls.AddControl(maxHeartRateResultText);
            #endregion

            #region Fitness Level
            ColorableLabel fitnessLabel = new ColorableLabel("Fitness Level", textColor, borderColor, _attachToEngine: false);
            fitnessLabel.Position = new Vector2(weightResultLabel.Position.x, restingHeartRateLabel.Position.y + 2);

            resultMenu.Controls.AddControl(fitnessLabel);

            ColorableLabel fitnessLevelText = new ColorableLabel("Error", new RenderColor(ConsoleColor.Red, ConsoleColor.Black), borderColor, _attachToEngine: false);
            fitnessLevelText.Position = new Vector2(fitnessLabel.Position.x + fitnessLabel.Size.x - 1, fitnessLabel.Position.y);

            fitnessLevelText.OnUpdate += (c) =>
            {
                try
                {
                    fitnessLevelText.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);
                    fitnessLevelText.Text = fitness.GetFitnessLevel().ToString();
                }
                catch ( DivideByZeroException )
                {
                    fitnessLevelText.TextColor = new RenderColor(ConsoleColor.Red, ConsoleColor.Black);
                    fitnessLevelText.Text = "Error";
                }
            };

            resultMenu.Controls.AddControl(fitnessLevelText);
            #endregion

            #region VO2 Max
            ColorableLabel vO2Label = new ColorableLabel("VO2 Max Score", textColor, borderColor, _attachToEngine: false);
            vO2Label.Position = new Vector2(weightResultLabel.Position.x, fitnessLabel.Position.y + 2);

            resultMenu.Controls.AddControl(vO2Label);

            ColorableLabel vO2Text = new ColorableLabel("Error", new RenderColor(ConsoleColor.Red, ConsoleColor.Black), borderColor, _attachToEngine: false);
            vO2Text.Position = new Vector2(vO2Label.Position.x + vO2Label.Size.x - 1, vO2Label.Position.y);

            vO2Text.OnUpdate += (c) =>
            {
                try
                {
                    vO2Text.TextColor = new RenderColor(ConsoleColor.Green, ConsoleColor.Black);
                    vO2Text.Text = fitness.GetFitnessLevel().ToString();
                }
                catch ( DivideByZeroException )
                {
                    vO2Text.TextColor = new RenderColor(ConsoleColor.Red, ConsoleColor.Black);
                    vO2Text.Text = "Error";
                }
            };

            resultMenu.Controls.AddControl(vO2Text);
            #endregion

            #region Back Button
            ColorableOption resultMenuBackButton = new ColorableOption("Back ", textColor, borderColor, _attachToEngine: false)
            {
                SelectedIndex = Vector2.Zero
            };
            resultMenuBackButton.Position = new Vector2(Vector2.CenterX(resultMenuBackButton.Size.x), vO2Label.Position.y + 4);

            resultMenuBackButton.OnSelect += (s) =>
            {
                #region Hide Data Menu
                OiskiEngine.Input.ResetInput();
                OiskiEngine.Input.ResetSlection();
                s.BorderStyle(BorderArea.Horizontal, '-');

                resultMenu.Show(false);
                #endregion

                mainMenu.Controls.GetSelectableControls[0].BorderStyle(BorderArea.Horizontal, '~');
                mainMenu.Show();
            };

            resultMenu.Controls.AddControl(resultMenuBackButton);
            #endregion

            #endregion
        }
    }
}
