using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace HKTranslator1._5
{
    public class HKTranslator1._5 : Mod
    {
        internal static HKTranslator1._5 Instance;

    //public override List<ValueTuple<string, string>> GetPreloadNames()
    //{
    //    return new List<ValueTuple<string, string>>
    //    {
    //        new ValueTuple<string, string>("White_Palace_18", "White Palace Fly")
    //    };
    //}

    //public HKTranslator1._5() : base("HKTranslator1._5")
    //{
    //    Instance = this;
    //}

    public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
    {
        Log("Initializing");

        Instance = this;

        Log("Initialized");
    }
}
}