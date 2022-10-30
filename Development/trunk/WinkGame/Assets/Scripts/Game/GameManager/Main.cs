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
            ocAnime.RunLeftWinkAnime();�@// ��ʂƎ��ۂ̖ڂ̈ʒu�͋��ʔ��]�ƂȂ邽��
            isDoneRightWink = true;
        }
        else
        {
            // �w�莞�Ԍo�߂���܂ł̓A�j���[�V�����̎��s�𖳌�������
            stackTimeRightWink += Time.deltaTime;
            if(stackTimeRightWink > detectDisableTime)
            {
                isDoneRightWink = false;
                stackTimeRightWink -= detectDisableTime;
            }
        }


        if (winkData.left_wink && !(isDoneLeftWink))
        {
            ocAnime.RunRightWinkAnime();�@// ��ʂƎ��ۂ̖ڂ̈ʒu�͋��ʔ��]�ƂȂ邽��
            isDoneLeftWink = true;
        }
        else
        {
            // �w�莞�Ԍo�߂���܂ł̓A�j���[�V�����̎��s�𖳌�������
            stackTimeLeftWink += Time.deltaTime;
            if (stackTimeLeftWink > detectDisableTime)
            {
                isDoneLeftWink = false;
                stackTimeLeftWink -= detectDisableTime;
            }
        }
        
    }
}
