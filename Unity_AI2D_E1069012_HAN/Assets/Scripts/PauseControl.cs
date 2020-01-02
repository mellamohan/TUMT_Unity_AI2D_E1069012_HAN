using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    [Header("暫停介面")]
    public Image imagePause;
    public Sprite spritePause, spritePlay;

    public bool pause;


    /// <Summary>
    ///暫停方法
    ///<Summary>
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Pause!");
            // ! 相反 : 將布林值改為相反
            pause = !pause;

            //條件運算子
            //布林值 ? 結果一 : 結果二
            //布林值 ? true 會執行結果一
            //布林值 ? false 會執行結果二

            //暫停介面.圖片 = 暫停布林值 ? 打勾/取敲時更換圖片
            imagePause.sprite = pause ? spritePlay : spritePause;

            Time.timeScale = pause ? 0 : 1;
        }

    }

    //更新 : 一秒執行約60秒
    private void Update()
    {
        Pause();
    }

}
