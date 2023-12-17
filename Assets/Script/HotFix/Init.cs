using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Unity.Hotfix
{
    public class Init 
    {
        static ResourcesComponent res;
        static Transform canvas;
        public static void Start() {

            Debug.Log("热更新dll的入口!");
            res = GameObject.Find("ResourcesComponent").GetComponent<ResourcesComponent>();
            canvas = GameObject.Find("Canvas").transform;

           UnityEngine.Object go = res.GetAsset("LoginPanel", "prefab/LoginPanel");
           GameObject loginPanel=(GameObject)GameObject.Instantiate(go);
            loginPanel.transform.SetParent(canvas, false);

            loginPanel.transform.Find("logonBtn").GetComponent<Button>().onClick.AddListener(logonBtnOnClick);
            //res.UnloadBundle("prefab/LoginPanel");
        }

        private static void logonBtnOnClick()
        {
            res.GetAsset("mobaScene", "scene/mobaScene",true);
            SceneManager.LoadScene("mobaScene");
            Debug.Log("进入场景!");
            //res.UnloadBundle("prefab/LoginPanel");

        }
    }
}