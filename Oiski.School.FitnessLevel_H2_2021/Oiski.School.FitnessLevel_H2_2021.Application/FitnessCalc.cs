using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.FitnessLevel_H2_2021.Application
{
    /// <summary>
    /// Defines a basic calculator for figuring out a persons Fitness Level and V02 Max Score
    /// </summary>
    public class FitnessCalc
    {
        /// <summary>
        /// The persons weight in kilograms
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// The persons heart rate, while resting, in Beats Pr. Minute (BPM)
        /// </summary>
        public int RestingHeartRate { get; set; }
        /// <summary>
        /// The maximum heart rate, while exercising, in Beats Pr. Minute (BPM)
        /// </summary>
        public int MaxHeartRate { get; set; }

        /// <summary>
        /// Calculates the <strong>Fitness Level</strong> of a person based on his/her <see cref="MaxHeartRate"/> and <see cref="RestingHeartRate"/>
        /// </summary>
        /// <returns>An <see langword="int"/> value rounded to the nearest integer that represents a persons <strong>Fitness Level</strong></returns>
        public int GetFitnessLevel ()
        {
            return ( int ) Math.Round(( MaxHeartRate / RestingHeartRate ) * 15.3);
        }

        /// <summary>
        /// Calculates a person <strong>VO2 Max Score</strong> based on <see cref="GetFitnessLevel"/> and the persons <see cref="Weight"/>
        /// </summary>
        /// <returns>A <see langword="decimal"/> value truncated to 1 decimal point that represents a persons <strong>VO2 Max Score</strong></returns>
        public decimal GetVO2Max ()
        {
            return Math.Truncate(( GetFitnessLevel() * Weight ) / 1000);
        }
    }
}