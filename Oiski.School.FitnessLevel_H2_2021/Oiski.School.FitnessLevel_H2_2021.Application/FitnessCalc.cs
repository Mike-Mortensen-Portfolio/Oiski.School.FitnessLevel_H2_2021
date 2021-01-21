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
    }
}