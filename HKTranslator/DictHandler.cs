using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

namespace HKTranslator
{
    static class DictHandler
    {
        private static Dictionary<string, string> TranslateDict = new Dictionary<string, string>();

        // Checks whether the dictionary was generated.
        private static bool DictActive;


        public static void Initialize()
        {
            XmlDocument doc = new XmlDocument();
            DictActive = LoadXML(ref doc);
            if (DictActive)
            {
                CreateDicts(doc);
            }
        }

        public static bool LoadXML(ref XmlDocument xml)
        {
            if (!File.Exists(Path.Combine(Application.persistentDataPath, "TranslatorDictionary.xml")))
            {
                Log("TranslatorDictionary.xml missing! Please add TranslatorDictionary.xml to your saves folder. Can be found here: https://github.com/ManicJamie/HKTranslator/blob/master/TranslatorDictionary.xml");
                return false;
            }
            xml.Load(Path.Combine(Application.persistentDataPath, "TranslatorDictionary.xml"));
            Log("Translation XML loaded.");
            return true;
        }

        public static void CreateDicts(XmlDocument xml)
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

        private static void Log(string message)
        {
            HKTranslator.Instance.Log(message);
        }
    }
}
