﻿using UnityEngine;

namespace PulsarPluginLoader.Utilities
{
    public static class Clipboard
    {
        public static void Copy(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }

        public static string Paste()
        {
            return GUIUtility.systemCopyBuffer;
        }
    }
}
