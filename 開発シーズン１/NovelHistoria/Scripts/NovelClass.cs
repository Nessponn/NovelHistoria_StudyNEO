using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NovelClass
{
    //この命令はプレイヤーの意思によって飛ばせないようにするか
    //させないとしたら何秒後に偏移させるか

    //基本ノベルパラメータ
    public NovelParameter NovelParameter;

    [Space]
    //画像や立ち絵に対するパラメータ
    public ActionParameter AnimationParameter;

    [Space]
    //音楽や効果音に関するパラメータ
    public MusicParameter MusicParameter;

    //キャラクターに関するパラメーター
    [Space]
    public CharacterParameter CharacterParameter;
}

[System.Serializable]
public class NovelParameter
{
    public string Name;//ネームテキスト
    [TextArea(3, 10)] public string Text;//テキスト本文
    
    public float InterbalTime = 0.02f;//会話文全表示に所要する時間(デフォルトは0.02秒)

    //BranchParameterとして新設すべきでは？？？？？？？
    public bool ChoicesObject;//選択肢を設けるか
    public string Branch1;//選択肢１
    public NovelTaker Branch1_Novel;
    public string Branch2;//選択肢２
    public NovelTaker Branch2_Novel;
    //本当だったら、文章の割り込ませ方について選択できるようにするべきだが、時間がないんで無理です

    public bool ResidualText;//このテキストをクリックしても残留させたままにする
}

[System.Serializable]
public class ActionParameter//あとでBackGroundPrameterに改名して、背景に関する処理専門にしとく
{
    public Sprite Image;//背景画像（あれば変更される）
    public Color Color = Color.white;//背景の色味(白が初期値の方が、扱いやすい気がする)

    [Space]
    public Transform pos;//スクロール先の座標
    public float TransTime;//座標に移動するまでに要する所要時間
    [Range(0, 1)] public float Timing;//会話中のどの比率のタイミングでアクションを発火させるか
    public bool DoAfterTalk;//会話終了後に実行
}

[System.Serializable]
//曲や効果音に関して設定を行う
public class MusicParameter
{
    public AudioClip BGM;//流したい音楽
    public AudioClip SE;
    public bool StopBGM;
}

[System.Serializable]
//キャラクターに関して設定を行う
public class CharacterParameter
{
    public CharacterSetting[] Character;
}

[System.Serializable]
//命令を行うキャラクターの情報
public class CharacterSetting
{
    public character Character;//雑な設計ですんません…

    public position Position;

    public emotion Emotion;

    public enum character
    {
        キャラクター１ = 0,
        キャラクター２ = 1,
        キャラクター３ = 2
    }

    //位置
    public enum position
    {
        左 = 0,  //0
        中央 = 1,//1
        右 = 2,   //2
        フェードアウト = 3//3
    }

    //感情（表情差分設定）
    public enum emotion
    {
        変更なし = 0,
        喜 = 1,
        怒 = 2,
        哀 = 3,
        楽 = 4
    }
}