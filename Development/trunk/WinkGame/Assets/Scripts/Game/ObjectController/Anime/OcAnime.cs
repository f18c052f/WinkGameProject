using UnityEngine;


namespace ObjectController.Anime
{
    public class OcAnime : MonoBehaviour
    {
        [SerializeField] private Animator animeRightWink;
        [SerializeField] private Animator animeLeftWink;


        /*--- APIs ---*/
        public void RunRightWinkAnime()
        {
            animeRightWink.SetTrigger("right_wink_trigger");
        }

        public void RunLeftWinkAnime()
        {
            animeLeftWink.SetTrigger("left_wink_trigger");
        }

    }
}

