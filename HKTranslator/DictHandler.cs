using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;
using System.ComponentModel;
using System.Resources;

namespace HKTranslator
{
    static class DictHandler
    {
        private static Dictionary<string, string> TranslateDict = new Dictionary<string, string>();

        // Address of the default dictionary, in case user does not already have TranslatorDictionary.xml in their saves folder.
        private const string DICTURI = "https://raw.githubusercontent.com/ManicJamie/HKTranslator/master/HKTranslator/dictionary.xml";

        private static readonly ManualResetEvent downloading = new ManualResetEvent(false);

        // XML document. Disposed after loading.
        private static XmlDocument xml;

        // Checks whether the dictionary was generated.
        private static bool DictActive;


        public static void Initialize()
        {
            DictActive = LoadXML();
            if (DictActive)
            {
                CreateDicts();
                xml = null;
            }
        }

        public static bool LoadXML()
        {
            if (!File.Exists(Path.Combine(Application.persistentDataPath, "TranslatorDictionary.xml")))
            {
                //xml = new XmlDocument();
                //xml.LoadXml(Properties.Resources.TranslatorDictionary);
                //return true;
                Log("TranslatorDictionary.xml missing! Please add TranslatorDictionary.xml to your saves folder. Can be found here: https://github.com/ManicJamie/HKTranslator/blob/master/TranslatorDictionary.xml");
                return false;
            }
            xml = new XmlDocument();
            xml.Load(Path.Combine(Application.persistentDataPath, "TranslatorDictionary.xml"));
            Log("Translation XML loaded.");
            return true;
        }

        public static void CreateDicts()
        {
            TranslateDict = new Dictionary<string, string>();
            foreach (XmlNode node in xml.DocumentElement.ChildNodes) // Iterate through each <entry> tag in dictionary.
            {
                if (!node.OuterXml.Contains("<!--")) TranslateDict.Add(node.SelectSingleNode("oldName").InnerText, node.SelectSingleNode("newName").InnerText);
            }
        }

        public static string TranslateSceneName(string oldName)
        {
            string newName;
            if (DictActive && TranslateDict.TryGetValue(oldName, out newName))
            {
                return newName;
            }
            return oldName;
        }

        public static string TranslateTransitionName(string oldName)
        {
            if (!DictActive) { return oldName; }
            string[] transitionArray = oldName.Split('[', ']');
            return TranslateSceneName(transitionArray[0]) + '[' + transitionArray[1] + ']';
        }

        public static string TranslateTransitionPair(string pair)
        {
            string[] pairArray = pair.Split('{', '}');
            return $"{{{TranslateTransitionName(pairArray[1])}}}-->{{{TranslateTransitionName(pairArray[3])}}}";
        }

        /*
         * Deprecated, but may need at some point so I'll keep it here.
        public static string ReverseSceneTranslation(string oldName)
        {
            if (!DictActive) { return oldName; }

            string newName;
            if (TranslateDict.TryGetValue(oldName, out newName))
            {
                return newName;
            }
            return oldName;
        }

        public static string ReverseTransitionTranslation(string oldName)
        {
            if (!DictActive) { return oldName; }
            string[] transitionArray = oldName.Split('[', ']');
            return TranslateSceneName(transitionArray[0]) + '[' + transitionArray[1] + ']';
        }
        */

        private static void Log(string message)
        {
            HKTranslator.Instance.Log(message);
        }
    }
}
