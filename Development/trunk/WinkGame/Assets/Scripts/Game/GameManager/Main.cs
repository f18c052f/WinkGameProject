using UnityEngine;
using ObjectController.Anime;

public class Main : MonoBehaviour
{
    /*--- references ---*/
    public WinkData winkData;
    public OcAnime ocAnime;

    /*--- properties ---*/
    public float detectDisableTime = 2.0f;

    /*--- member ---*/
    private float stackTimeRightWink = 0.0f;
    private float stackTimeLeftWink = 0.0f;
    private bool isDoneRightWink = false;
    private bool isDoneLeftWink = false;
  
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (winkData.right_wink && !(isDoneRightWink))
        {
            ocAnime.RunLeftWinkAnime();　// 画面と実際の目の位置は鏡面反転となるため
            isDoneRightWink = true;
        }
        else
        {
            // 指定時間経過するまではアニメーションの実行を無効化する
            stackTimeRightWink += Time.deltaTime;
            if(stackTimeRightWink > detectDisableTime)
            {
                isDoneRightWink = false;
                stackTimeRightWink -= detectDisableTime;
            }
        }


        if (winkData.left_wink && !(isDoneLeftWink))
        {
            ocAnime.RunRightWinkAnime();　// 画面と実際の目の位置は鏡面反転となるため
            isDoneLeftWink = true;
        }
        else
        {
            // 指定時間経過するまではアニメーションの実行を無効化する
            stackTimeLeftWink += Time.deltaTime;
            if (stackTimeLeftWink > detectDisableTime)
            {
                isDoneLeftWink = false;
                stackTimeLeftWink -= detectDisableTime;
            }
        }
        
    }
}
