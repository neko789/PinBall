using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private int score = 0;
    private int totalscore = 0;

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject TotalScoreText;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.TotalScoreText = GameObject.Find("TotalScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        this.TotalScoreText.GetComponent<Text>().text = "TotalScore :" + totalscore;
        //ボールが画面外に出た場合
        if (this.score >= 0)
        {
            this.totalscore += this.score;
            this.score -= this.score;
        }
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
            this.score = 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.score = 50 ;
        }
        else if (other.gameObject.tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.score = 20;
        }

    }
}