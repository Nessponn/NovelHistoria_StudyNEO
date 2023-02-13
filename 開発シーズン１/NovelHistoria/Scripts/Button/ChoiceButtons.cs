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

    //�I�����̕��������󂯎��
    public void NovelBranch(NovelTaker DATA, int Number,string[] branches)
    {
        karioki = DATA;
        karinum = Number;

        Button1Tx.GetComponent<Text>().text = branches[0];
        Button2Tx.GetComponent<Text>().text = branches[1];

        Start_BranchAnim();

        NovelSafetySystem.NovelSafety = false;//��b�i�s���b�N
    }

    //�I�����ꂽ�ۂɑI����������Ԃ�
    public void Send_Branch(int num)
    {
        if (num == 0) karioki.nextNovel = karioki.NS[karinum].NovelParameter.Branch1_Novel;
        else karioki.nextNovel = karioki.NS[karinum].NovelParameter.Branch2_Novel;

        End_BranchAnim();
    }

    //�I������\������A�j���[�V����
    private void Start_BranchAnim()
    {
        ButtonGroup.DOFade(1, 1f);//�{�^����t����
        Button1.GetComponent<RectTransform>().DOAnchorPosX(0, 0.8f);
        Button2.GetComponent<RectTransform>().DOAnchorPosX(0, 0.8f);

        //�I�����ł��邱�Ƃ𕪂���₷�����邽�߂ɁA������Ɖ�ʂ��Â����鉉�o������
        BlackScreen.gameObject.SetActive(true);
        BlackScreen.DOFade(0.55f, 0.5f);
    }

    private void End_BranchAnim()
    {
        ButtonGroup.DOFade(0, 1f);//�{�^��������
        Button1.GetComponent<RectTransform>().DOAnchorPosX(1000,0.8f);
        Button2.GetComponent<RectTransform>().DOAnchorPosX(-1000,0.8f);

        //�Ó]������
        BlackScreen.DOFade(0, 0.5f);

        //��b�i�s������
        DOVirtual.DelayedCall(0.5f, () =>
        {
            BlackScreen.gameObject.SetActive(false);
            NovelHistoria.Historia.Pressed = true;//�����ŃN���b�N������o���A��b��i�߂�
            NovelSafetySystem.NovelSafety = true;//��b�i�s����
        }
        );
    }
}
