using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private int totalscore = 0;

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private Text TotalScoreText;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.TotalScoreText = GameObject.Find("TotalScoreText").GetComponent<Text>();
        this.TotalScoreText.text = "TotalScore :" + totalscore;
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合

        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            Addscore(10);
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            Addscore(50);
        }
        else if (other.gameObject.tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            Addscore(20);
        }

    }
    void Addscore(int score)
    {
        this.totalscore += score;
        this.TotalScoreText.text = "TotalScore :" + totalscore;
    }
}