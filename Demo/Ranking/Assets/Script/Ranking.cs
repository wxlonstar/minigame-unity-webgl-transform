﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class Ranking : MonoBehaviour
{
    public Button ShowButton;
    public Button CloseButton;
    public RawImage RankBody;
    public GameObject RankingBox;

    void Start()
    {
        WX.InitSDK((code)=> {

            Init();
        });
    }

    void Init()
    {

        ShowButton.onClick.AddListener(()=> {
            RankingBox.SetActive(true);
            // 如果父元素占满整个窗口的话，pivot 设置为（0，0），rotation设置为180，则左上角就是离屏幕的距离
            // 注意这里传x,y,width,height是为了点击区域能正确点击，x,y 是距离屏幕左上角的距离，宽度传 (int)RankBody.rectTransform.rect.width是在canvas的UI Scale Mode为 Constant Pixel Size的情况下设置的。如果是Scale With Screen Size则要这要做一下换算，比如canavs宽度为750，rawImage设置为690 则应该传Screen.width*(690/750)。高度的同理。
            var p = RankBody.transform.position;
            WX.ShowOpenData(RankBody.texture, (int)p.x, Screen.height-(int)p.y, (int)RankBody.rectTransform.rect.width, (int)RankBody.rectTransform.rect.height);
        });

        CloseButton.onClick.AddListener(()=> {
            RankingBox.SetActive(false);
            WX.HideOpenData();
        });
    }

}
