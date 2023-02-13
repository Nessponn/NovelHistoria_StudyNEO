using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChoiceButtons : SingletonMonoBehaviourFast<ChoiceButtons>
{
    public CanvasGroup ButtonGroup;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button1Tx;
    public GameObject Button2Tx;
    public Image BlackScreen;

    private NovelTaker karioki;
    private int karinum;

    private void Start()
    {
        BlackScreen.gameObject.SetActive(false);
    }

    //選択肢の文字情報を受け取る
    public void NovelBranch(NovelTaker DATA, int Number,string[] branches)
    {
        karioki = DATA;
        karinum = Number;

        Button1Tx.GetComponent<Text>().text = branches[0];
        Button2Tx.GetComponent<Text>().text = branches[1];

        Start_BranchAnim();

        NovelSafetySystem.NovelSafety = false;//会話進行ロック
    }

    //選択された際に選択した情報を返す
    public void Send_Branch(int num)
    {
        if (num == 0) karioki.nextNovel = karioki.NS[karinum].NovelParameter.Branch1_Novel;
        else karioki.nextNovel = karioki.NS[karinum].NovelParameter.Branch2_Novel;

        End_BranchAnim();
    }

    //選択肢を表示するアニメーション
    private void Start_BranchAnim()
    {
        ButtonGroup.DOFade(1, 1f);//ボタンを付ける
        Button1.GetComponent<RectTransform>().DOAnchorPosX(0, 0.8f);
        Button2.GetComponent<RectTransform>().DOAnchorPosX(0, 0.8f);

        //選択肢であることを分かりやすくするために、ちょっと画面を暗くする演出をする
        BlackScreen.gameObject.SetActive(true);
        BlackScreen.DOFade(0.55f, 0.5f);
    }

    private void End_BranchAnim()
    {
        ButtonGroup.DOFade(0, 1f);//ボタンを消す
        Button1.GetComponent<RectTransform>().DOAnchorPosX(1000,0.8f);
        Button2.GetComponent<RectTransform>().DOAnchorPosX(-1000,0.8f);

        //暗転を解除
        BlackScreen.DOFade(0, 0.5f);

        //会話進行を解禁
        DOVirtual.DelayedCall(0.5f, () =>
        {
            BlackScreen.gameObject.SetActive(false);
            NovelHistoria.Historia.Pressed = true;//自動でクリック判定を出し、会話を進める
            NovelSafetySystem.NovelSafety = true;//会話進行解禁
        }
        );
    }
}
