﻿using HarmonyLib;
using System;
using UnityEngine;

namespace PulsarPluginLoader.Utilities
{
    [HarmonyPatch(typeof(PLNetworkManager), "Start")]
    class ExceptionWarningPatch
    {
        private static void Prefix()
        {
            Application.logMessageReceived += OnUnityLog;
        }

        private static void OnUnityLog(string line, string stackTrace, LogType type)
        {
            if (type.Equals(LogType.Exception))
            {
                string id = String.Format("{0:X}", DateTime.UtcNow.GetHashCode()).Substring(0, 7).ToUpper();
                string msg = $"<color='#{ColorUtility.ToHtmlStringRGB(Color.red)}'>Exception!</color> {id}";

                Messaging.Notification(PLNetworkManager.Instance.LocalPlayer.GetPhotonPlayer(), msg);
                Logger.Info($"Exception ID: {id}");
            }
        }
    }
}
