using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NovelClass
{
    //���̖��߂̓v���C���[�̈ӎv�ɂ���Ĕ�΂��Ȃ��悤�ɂ��邩
    //�����Ȃ��Ƃ����牽�b��ɕΈڂ����邩

    //��{�m�x���p�����[�^
    public NovelParameter NovelParameter;

    [Space]
    //�摜�◧���G�ɑ΂���p�����[�^
    public ActionParameter AnimationParameter;

    [Space]
    //���y����ʉ��Ɋւ���p�����[�^
    public MusicParameter MusicParameter;

    //�L�����N�^�[�Ɋւ���p�����[�^�[
    [Space]
    public CharacterParameter CharacterParameter;
}

[System.Serializable]
public class NovelParameter
{
    public string Name;//�l�[���e�L�X�g
    [TextArea(3, 10)] public string Text;//�e�L�X�g�{��
    
    public float InterbalTime = 0.02f;//��b���S�\���ɏ��v���鎞��(�f�t�H���g��0.02�b)

    //BranchParameter�Ƃ��ĐV�݂��ׂ��ł́H�H�H�H�H�H�H
    public bool ChoicesObject;//�I������݂��邩
    public string Branch1;//�I�����P
    public NovelTaker Branch1_Novel;
    public string Branch2;//�I�����Q
    public NovelTaker Branch2_Novel;
    //�{����������A���͂̊��荞�܂����ɂ��đI���ł���悤�ɂ���ׂ������A���Ԃ��Ȃ���Ŗ����ł�

    public bool ResidualText;//���̃e�L�X�g���N���b�N���Ă��c���������܂܂ɂ���
}

[System.Serializable]
public class ActionParameter//���Ƃ�BackGroundPrameter�ɉ������āA�w�i�Ɋւ��鏈�����ɂ��Ƃ�
{
    public Sprite Image;//�w�i�摜�i����ΕύX�����j
    public Color Color = Color.white;//�w�i�̐F��(���������l�̕����A�����₷���C������)

    [Space]
    public Transform pos;//�X�N���[����̍��W
    public float TransTime;//���W�Ɉړ�����܂łɗv���鏊�v����
    [Range(0, 1)] public float Timing;//��b���̂ǂ̔䗦�̃^�C�~���O�ŃA�N�V�����𔭉΂����邩
    public bool DoAfterTalk;//��b�I����Ɏ��s
}

[System.Serializable]
//�Ȃ���ʉ��Ɋւ��Đݒ���s��
public class MusicParameter
{
    public AudioClip BGM;//�����������y
    public AudioClip SE;
    public bool StopBGM;
}

[System.Serializable]
//�L�����N�^�[�Ɋւ��Đݒ���s��
public class CharacterParameter
{
    public CharacterSetting[] Character;
}

[System.Serializable]
//���߂��s���L�����N�^�[�̏��
public class CharacterSetting
{
    public character Character;//�G�Ȑ݌v�ł���܂���c

    public position Position;

    public emotion Emotion;

    public enum character
    {
        �L�����N�^�[�P = 0,
        �L�����N�^�[�Q = 1,
        �L�����N�^�[�R = 2
    }

    //�ʒu
    public enum position
    {
        �� = 0,  //0
        ���� = 1,//1
        �E = 2,   //2
        �t�F�[�h�A�E�g = 3//3
    }

    //����i�\����ݒ�j
    public enum emotion
    {
        �ύX�Ȃ� = 0,
        �� = 1,
        �{ = 2,
        �� = 3,
        �y = 4
    }
}