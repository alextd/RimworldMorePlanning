﻿using System;
using HugsLib;
using RimWorld;
using System.Collections.Generic;
using Verse;
using System.Reflection;
using HugsLib.Settings;
using UnityEngine;

namespace MorePlanning
{
    public class PlanColorManager
    {
        public const int NumPlans = 10;

        public static Color[] planColor = new Color[NumPlans];

        private static SettingHandle<string>[] planColorSetting = new SettingHandle<string>[NumPlans];

        private static string[] defaultColors = new string[NumPlans] {
            "a9a9a9",
            "2095f2",
            "4bae4f",
            "f34235",
            "feea3a",
            "ff00f0",
            "00fffc",
            "8400ff",
            "ffa200",
            "000000"
        };

        private static string getDefaultColor(int i)
        {
            return defaultColors[i];
        }

        public static void Load(ModSettingsPack Settings)
        {
            for (int i = 0; i < NumPlans; i++)
            {
                planColorSetting[i] = Settings.GetHandle<string>("planColor" + i, "planColor" + i, "planColor" + i, PlanColorManager.getDefaultColor(i));
            }

            for (int i = 0; i < NumPlans; i++)
            {
                Color color = new Color();
                ColorUtility.TryParseHtmlString("#" + planColorSetting[i], out color);

                planColor[i] = color;
                
                Resources.planMatColor[i].SetColor("_Color", color);
            }
        }
    }
}