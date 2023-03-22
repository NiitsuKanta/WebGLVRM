// scripts/WebGLVRMOpenFile.cs
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UniVRM10;
using VRMShaders;

public class WebGLVRMOpenFile : MonoBehaviour
{
    // plugin����֐���ǂݍ���
    [DllImport("__Internal")]
    private static extern void CreateInput();
    [DllImport("__Internal")]
    private static extern void ClickInput();

    // input�^�O�𐶐�����
    void Start()
    {
        CreateInput();
    }

    // �{�^�����N���b�N�����Ƃ��̏���
    public void UploadButtonClick()
    {
        ClickInput();
    }

    // input�^�O�ɕύX���������Ƃ��ɌĂяo�����
    // url�ɂ�input�őI�������t�@�C����blob���n�����
    public void FileSelected(string url)
    {
        Debug.Log(url);
        StartCoroutine(LoadFile(url));
    }

    // blob����o�C�g�z���ǂݍ���ŁAVRM�����[�h����
    private IEnumerator LoadFile(string url)
    {
        yield return new WaitForSeconds(0.1f);
        WWW www = new WWW(url);
        yield return www;

        byte[] fileContent = www.bytes;

        Vrm10.LoadBytesAsync(fileContent,true,new ControlRigGenerationOption(),true, new RuntimeOnlyNoThreadAwaitCaller());
    }
}