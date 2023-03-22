// scripts/WebGLVRMOpenFile.cs
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UniVRM10;
using VRMShaders;

public class WebGLVRMOpenFile : MonoBehaviour
{
    // pluginから関数を読み込む
    [DllImport("__Internal")]
    private static extern void CreateInput();
    [DllImport("__Internal")]
    private static extern void ClickInput();

    // inputタグを生成する
    void Start()
    {
        CreateInput();
    }

    // ボタンをクリックしたときの処理
    public void UploadButtonClick()
    {
        ClickInput();
    }

    // inputタグに変更があったときに呼び出される
    // urlにはinputで選択したファイルのblobが渡される
    public void FileSelected(string url)
    {
        Debug.Log(url);
        StartCoroutine(LoadFile(url));
    }

    // blobからバイト配列を読み込んで、VRMをロードする
    private IEnumerator LoadFile(string url)
    {
        yield return new WaitForSeconds(0.1f);
        WWW www = new WWW(url);
        yield return www;

        byte[] fileContent = www.bytes;

        Vrm10.LoadBytesAsync(fileContent,true,new ControlRigGenerationOption(),true, new RuntimeOnlyNoThreadAwaitCaller());
    }
}