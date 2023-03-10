using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum NamaScene
    {
        kosong,
        MetaGame,
        ConnectingTheDot,
        SpellingBee,
        PilihanGanda,
        BenarSalah,
    }

    public NamaScene namaScene;

    public static GameManager instance;
    public GameObject notifTextUI;
    public OpeningTextMiniGame openingTextMiniGame;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;

    }

    private void Start()
    {

        if (namaScene == NamaScene.ConnectingTheDot)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Hubungkan Teks dan Gambarnya!!!");

            AnimasiManager.instance.AnimasiScreenCTD(true);

            //Audio BGM
            AudioManager.instance.BgmConnectTheDots();
        }
        else if (namaScene == NamaScene.SpellingBee)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Isi garis yang kosong dengan huruf sesuai gambar!!!");
        }
        else if (namaScene == NamaScene.PilihanGanda)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Pilih Jawaban Yang Benar!!!");
        }
        else if (namaScene == NamaScene.BenarSalah)
        {
            openingTextMiniGame.gameObject.SetActive(true);
            openingTextMiniGame.TextOpening("Pilih Jawaban Yang Benar!!!");
        }
    }

    public void NotifTextUI(string text)
    {
        notifTextUI.SetActive(true);
        notifTextUI.transform.GetChild(1).gameObject.GetComponent<Text>().text = text;
    }
    public void PindahScene(string namaScene)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(namaScene);
        }
    }
    public void PindahSceneDelay(string namaScene, float delay)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(namaScene);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
