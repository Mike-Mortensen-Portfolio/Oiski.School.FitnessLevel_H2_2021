# Oiski's VO2 Calc

## About The Project
This repository is part of the `Oiski.School` namespace collection, which includes projects build as school assignments.

## The program
The assignments states that the following criteria:

**Goal**
>Build a console application that can calculate `FitnessLevel` based on a persons weight, resting heart rate and max heart rate.

**Input**
>The program must take in 3 values; `Weight`, `RestingHeartRate` and `MaxHeartRate`.
>Heart rate is measured in BPM (_Beats Pr. Minute_).

**Output**
>The application must present the `FitnessLevel`, rounded to the nearest integer value and be prefixed with `ml/kg/min`.
>In addition it must also present `VO2Max`, truncated to 1 decimal point as well as prefixed with `l/m`.

See the [Wiki](https://github.com/ZhakalenDk/Oiski.School.VO2Number_H2_2021/wiki) for more in depth information about the project.

## Versioning
The Assignment specifies that versioning should be done according to the following template: [_Major_].[_Minor_].[_Path_].\
Each `Feature` must be branched out and developed on an isolated branch and merged back into the `Developer` branch when done.

The syntax for the structure of folders must be presented as: [DeveloperName]/[Version]/[BranchName], where as branches should be named as follows: [*Version*]-[*Feature*]_[*SubFeature*].\
**Example:**
>**Folder Structure:** _Oiski/v1_ \
>**Branch Name:** _1.0.0-Interface_MainMenu_ \
>**Full Path:** _Oiski/v1/1.0.0-Interface_MainMenu__

### Change Log
- [v0.1.0](https://github.com/ZhakalenDk/Oiski.School.FitnessLevel_H2_2021/releases/tag/v0.1.0)
  - Implemented a basic Fitness Level Class
- [v0.2.0](https://github.com/ZhakalenDk/Oiski.School.FitnessLevel_H2_2021/releases/tag/v0.2.0)
  - Intergrated Fitness Level Calculations
- [v0.3.0](https://github.com/ZhakalenDk/Oiski.School.FitnessLevel_H2_2021/releases/tag/v0.3.0)
  - Intergrated VO2 Max Score Formula into the `FitnessCalc` Class
- [v1.0.0](https://github.com/ZhakalenDk/Oiski.School.FitnessLevel_H2_2021/releases/tag/v1.0.0)
  - Implementation of Basic Menu that can retrieve and display dat for a user through an interactive UI
- [v1.0.1 - Hotfix](https://github.com/ZhakalenDk/Oiski.School.FitnessLevel_H2_2021/releases/tag/v1.0.1)
  - Fixed a DivideByZeroException when entering the Result Menu
- [v1.0.2 - Hotfix](https://github.com/ZhakalenDk/Oiski.School.FitnessLevel_H2_2021/releases/tag/v1.0.2)
  - Resolved an issue where the program wouldn't proceed on _Any Key_ as described

## Oiski.School Namespace Collection
1. [Oiski.School.Library_h1_2020](https://github.com/ZhakalenDk/Oiski.School.Library_H1_2020)
2. [Oiski.School.Bank_H1_2020](https://github.com/ZhakalenDk/Oiski.School.Bank_H1_2020)
3. [Oiski.School.RainStatistic_H2_2021](https://github.com/ZhakalenDk/Oiski.School.RainStatistic_H2_2021)