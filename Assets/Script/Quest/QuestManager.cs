using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestManager : MonoBehaviour
{
    public GameObject questBG;
    public GameObject dialogWindow;

    int currentStage = 0;
    int[] encountTable;
    public int MAX_STAGE;


    SettingManager SettingManager => SettingManager.instance;
    SoundManager SoundManager => SoundManager.instance;
    StageUIManager StageUI => StageUIManager.instance;
    SceneTransitionManager SceneManager => SceneTransitionManager.instance;


    // Start is called before the first frame update
    void Start()
    {
        StageUI.updateUI(currentStage);

        DialogTextManager.instance.SetScenarios(new string[] { "ダンジョンについた" });

        SetEncount();
    }

    public void SetEncount()
    {
        encountTable = new int[MAX_STAGE];
    }

    private IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "探索中" });

        // 背景画像を拡大する.それを完了後に元の大きさに戻す.
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2.0f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
        // 背景画像をフェードアウトさせる.完了後に元の大きさに戻す.
        SpriteRenderer questBGSpriterenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriterenderer.DOFade(0, 2.0f)
            .OnComplete(() => questBGSpriterenderer.DOFade(1, 0));

        yield return new WaitForSeconds(2.0f);

        currentStage++;
        StageUI.updateUI(currentStage);

        if(currentStage == encountTable.Length)
        {
            StartCoroutine(GameClearDirecting());
        }
        else
        {
            StageUI.ButtonUIAppearance(true);
        }
    }

    public void OnNextButton()
    {
        SoundManager.PlayButtonSE(0);

        StageUI.ButtonUIAppearance(false);

        StartCoroutine(Searching());
    }

    private IEnumerator GameClearDirecting()
    {
        yield return new WaitForSeconds(SettingManager.instance.MessageSpeed / 3 * 2);

        DialogTextManager.instance.SetScenarios(new string[] { "探索中..." });
        // 背景画像を拡大する.それを完了後に元の大きさに戻す.
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2.0f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
        // 背景画像をフェードアウトさせる.完了後に元の大きさに戻す.
        SpriteRenderer questBGSpriterenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriterenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriterenderer.DOFade(1, 0));

        // 時間遅延.
        yield return new WaitForSeconds(2f);


        SoundManager.instance.StopBGM();    // BGMを停止させておく.
        SoundManager.instance.PlayButtonSE(13);

        StageUI.ClearUIAppearance();        // 宝箱を表示、他のステージUIは切っておく.

        DialogTextManager.instance.SetScenarios(new string[] { "宝物を見つけた！" });
        yield return new WaitForSeconds(4.0f);

        // フェードアウト.
        FadeIOManager.instance.FadeOut();

        SoundManager.instance.PlayBGM("Title");   // BGM.

        DialogTextManager.instance.SetScenarios(new string[] { "トレジャーハンターのあなたは\n街へ戻ると" });
        yield return new WaitForSeconds(2.0f);

        DialogTextManager.instance.SetScenarios(new string[] { "次のお宝を求めて旅だった……" });
        yield return new WaitForSeconds(4.0f);


        DialogTextManager.instance.SetScenarios(new string[] { "GAME CLEAR !! \n Thank you for Playing" });
        yield return new WaitForSeconds(4.0f);

        /*
        Player.UndoParameter();      // レベルに合わせて初期化.

        Player.PlayerInitPerBattleEnd();    // バトル終了ごとの初期化処理.

        // ---- セーブ.
        Userdata.level = Player.Level;
        Userdata.maxHP = Player.MaxHP;
        Userdata.hp = Player.Hp;
        Userdata.atk = Player.Atk;
        Userdata.spd = Player.Spd;
        Userdata.dodge = Player.Dodge;
        Userdata.critical = Player.Critical;
        Userdata.skill = Player.Skill;
        Userdata.nextEXP = Player.NextEXP;
        Userdata.nowEXP = Player.NowEXP;

        Userdata.messageSpeed = SettingManager.instance.MessageSpeed;
        Userdata.BGMvolume = SoundManager.instance.audioSourceBGM.volume;
        Userdata.SEvolume = SoundManager.instance.audioSourceSE.volume;

        SaveSystem.Instance.Save();

        // -----------
        */

        DialogTextManager.instance.SetScenarios(new string[] { "クリアデータをセーブしました" });
        yield return new WaitForSeconds(2.0f);

        DialogTextManager.instance.SetScenarios(new string[] { "タイトルの『つづきから』で\n現状の強さから再開できます" });
        yield return new WaitForSeconds(4.0f);

        CanvasGroup dialogCanvas = dialogWindow.GetComponent<CanvasGroup>();
        dialogCanvas.ignoreParentGroups = false;

        SoundManager.instance.StopBGM();    // BGMを停止させておく.

        SceneManager.LoadTo("Title");
    }
}
