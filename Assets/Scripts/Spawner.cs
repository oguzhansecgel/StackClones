using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public Score scoreScript;
    public Voice sound;
    public AudioSource SkorArtanSound;
    public ChangeColor changeColor;
    public Tile tileScript;
    [SerializeField]
    GameObject tile, bottomTile, startButton, settings, developer,modeSelect;
    [SerializeField]
    TMP_Text setText;
    TMP_Text scoreText;
    public Camera mainCamera;
    public GameObject textObject;
    public float textOffset = 2f;
    List<GameObject> stack;
    bool hasGameStarted, hasGameFinished;

    List<Color32> spectrum = new(){
        new Color32(255, 0, 0, 150)    ,
        new Color32(255, 12, 0, 160)   ,
        new Color32(255, 25, 0, 170)   ,
        new Color32(255, 38, 0, 200)   ,
        new Color32(255, 50, 0, 255)   ,
        new Color32(255, 63, 0, 255)   ,
        new Color32(255, 76, 0, 255)   ,
        new Color32(255, 89, 0, 255)   ,
        new Color32(255, 102, 0, 255)    ,
        new Color32(255, 114, 0, 255)     ,
        new Color32(255, 127, 0, 255)   ,
        new Color32(255, 140, 0, 255)   ,
        new Color32(255, 153, 0, 255)   ,
        new Color32(255, 165, 0, 255)   ,
        new Color32(255, 178, 0, 255),
        new Color32(255, 191, 0, 255)   ,
        new Color32(255, 204, 0, 255)   ,
        new Color32(255, 216,0, 255)   ,
        new Color32(255, 229, 0, 255)   ,
        new Color32(255, 242, 0, 255)   ,
        new Color32(255, 255, 0, 255)   ,
        new Color32(242, 255, 0, 255)   ,
        new Color32(229, 255, 0, 255)   ,
        new Color32(216, 255, 0, 255)   ,
        new Color32(204, 255, 0, 255)   ,
        new Color32(191, 255, 0, 255)   ,
        new Color32(178, 255, 0, 255)   ,
        new Color32(165, 255, 0, 255)   ,
        new Color32(153, 255, 0, 255)   ,
        new Color32(140, 255, 0, 255)   ,
        new Color32(127, 255, 0, 255)   ,
        new Color32(114, 255, 0, 255)   ,
        new Color32(101, 255, 0, 255)   ,
        new Color32(89, 255, 0, 255)   ,
        new Color32(76, 255, 0, 255)   ,
        new Color32(63, 255, 0, 255)   ,
        new Color32(50, 255, 0, 255)   ,
        new Color32(38, 255, 0, 255)   ,
        new Color32(25, 255, 0, 255)   ,
        new Color32(12, 255, 0, 255)   ,
        new Color32(0, 255, 0, 255)   ,
        new Color32(0, 224, 12, 255)   ,
        new Color32(0, 245, 25, 255)   ,
        new Color32(0, 222, 38, 255)   ,
        new Color32(0, 255, 51, 255)   ,
        new Color32(0, 255, 63, 255)   ,
        new Color32(0, 255, 76, 255)   ,
        new Color32(0, 255, 89, 255)   ,
        new Color32(0, 255, 101, 255)   ,
        new Color32(0, 255, 114, 255)   ,
        new Color32(0, 255, 127, 255)   ,
        new Color32(0, 255, 140, 255)   ,
        new Color32(0, 255, 153, 255)   ,
        new Color32(0, 255, 165, 255)   ,
        new Color32(0, 255, 178, 255)   ,
        new Color32(0, 255, 191, 255)   ,
        new Color32(0, 255, 203, 255)   ,
        new Color32(0, 255, 216, 255),
        new Color32(0, 255, 229, 255),
        new Color32(0, 255, 242, 255),
        new Color32(0, 255, 255, 255),
        new Color32(0, 242, 255, 255),
        new Color32(0, 229, 255, 255),
        new Color32(0, 216, 255, 255),
        new Color32(0, 203, 255, 255),
        new Color32(0, 191, 255, 255),
        new Color32(0, 178, 255, 255),
        new Color32(0, 165, 255, 255),
        new Color32(0, 153, 255, 255),
        new Color32(0, 140, 255, 255),
        new Color32(0, 127, 255, 255),
        new Color32(0, 114, 255, 255),
        new Color32(0, 101, 255, 255),
        new Color32(0, 89, 255, 255),
        new Color32(0, 76, 255, 255),
        new Color32(0, 63, 255, 255),
        new Color32(0, 51, 255, 255),
        new Color32(0, 38, 255, 255),
        new Color32(0, 25, 255, 255),
        new Color32(0, 12, 255, 255),
        new Color32(0, 0, 255, 255),
        new Color32(12, 0, 255, 255),
        new Color32(25, 0, 255, 255),
        new Color32(38, 0, 255, 255),
        new Color32(51, 63,255, 255),
    };
    int modifier;
    int colorIndex;
    public int currentScore;
    int sayac;
    public static Spawner instance;
    int skor = 0;
    int colorCount = 0;
    int overCount=0;
    int winCount = 0;
    private void Awake()
    {
       

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Sco").GetComponent<TMP_Text>();
        stack = new List<GameObject>();
        hasGameFinished = false;
        hasGameStarted = false;
        modifier = 1;
        colorIndex = 0;
        stack.Add(bottomTile);
        stack[0].GetComponent<Renderer>().material.color = spectrum[0];
        CreateTile();
        textObject.SetActive(false);
        if (sound.audioSource.mute == true)
        {
            setText.text = "Sound Off";
            setText.color = Color.red;
        }
        else
        {
            setText.text = "Sound On";
            setText.color = Color.green;
        }
        scoreScript.scoreWrite();
        tileScript.speed = 7f;

    }
    public void yazýKamera()
    {
        Vector3 cameraPosition = mainCamera.transform.position;

        // Yeni yazý konumu
        Vector3 textPosition = cameraPosition + new Vector3(mainCamera.transform.position.x+340f, mainCamera.transform.position.y, +22f);
        // Yazý nesnesinin konumunu güncelle
        textObject.transform.position = textPosition;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (hasGameFinished || !hasGameStarted) return;
        if (Input.GetMouseButtonDown(0))
        {
            yazýKamera();
            colorCount++;
            if (colorCount == 3)
            { 
                changeColor.BackColorChange();
                colorCount = 0;
            }

            if (stack.Count > 0)
            {
             
                stack[stack.Count - 1].GetComponent<Tile>().ScaleTile();
                
 
            }
            //yanma ve hýzlandýrma if else ifi
            if (stack[stack.Count - 1].transform.localScale == stack[stack.Count - 2].transform.localScale)
            {
                winCount++;
                overCount = 0;
                Debug.Log("scale degeri ayný win degeri : " + winCount + "over: " + overCount);
                if (winCount == 3)
                {
                    textObject.SetActive(false);
                    tileScript.speed = 7f;
                    winCount = 0;
                }
                else if (overCount > 0)
                {
                    tileScript.speed = 10f;
                }
                sayac++;
                if (sayac > 7)
                {
                    skor += 5;
                    SkorArtanSound.Play();
                    sayac = 0;
                }
            }
            else if (stack[stack.Count - 1].transform.localScale != stack[stack.Count - 2].transform.localScale)
            {
                overCount++;
                winCount = 0;
                Debug.Log("scale degeri farklý win degeri : " + winCount + "over: " + overCount);
                if (overCount==3)
                {
                    yazýKamera();
                    textObject.SetActive(true);               
                }
                else if (winCount > 0)
                {
                    textObject.SetActive(false);
                    tileScript.speed = 7f;
                }
            }



            if (hasGameFinished) return;
          
            scoreText.text = "Score : "+(stack.Count - 1+skor).ToString();
            StartCoroutine(MoveCamera());
            CreateTile();
            sound.PlayBlockHitSound();
            
        } 
        currentScore= (stack.Count - 1+skor);
    }

 

    IEnumerator MoveCamera()
    {
        float moveLength = 1f;
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        while(moveLength > 0)
        {
            float stepLength = 0.1f;
            moveLength -= stepLength;
            camera.transform.Translate(0, stepLength, 0, Space.World);
            yield return new WaitForSeconds(0.03f);
        }

    }
   

    void CreateTile()
    {
        GameObject previousTile = stack[stack.Count - 1];
        GameObject activeTile;
        activeTile = Instantiate(tile);
        stack.Add(activeTile);
        if (stack.Count > 2)
            activeTile.transform.localScale = previousTile.transform.localScale;

        activeTile.transform.position = new Vector3(previousTile.transform.position.x,
            previousTile.transform.position.y + previousTile.transform.localScale.y, previousTile.transform.position.z);

        colorIndex += modifier;
        if (colorIndex == spectrum.Count || colorIndex == -1)
        {
            modifier *= -1;
            colorIndex += 2 * modifier;
        }

        activeTile.GetComponent<Renderer>().material.color = spectrum[colorIndex];
        activeTile.GetComponent<Tile>().moveX = stack.Count % 2 == 0;

    }


    public void GameOver()
    {
        startButton.SetActive(true);
        settings.SetActive(true);
        developer.SetActive(true);
        hasGameFinished = true;
        textObject.SetActive(false);
        StartCoroutine(EndCamera());
        currentScore = (stack.Count - 1 + skor);
        scoreScript.ScoreCheck();
        scoreScript.highScoreText.gameObject.SetActive(true);
        scoreScript.ScoreCheck();
    }

    IEnumerator EndCamera()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 temp = camera.transform.position;
        Vector3 final = new Vector3(temp.x, temp.y - stack.Count*0.5f , temp.z);
        float cameraSizeFinal = stack.Count * 0.65f;
        while(camera.GetComponent<Camera>().orthographicSize < cameraSizeFinal)
        {
            camera.GetComponent<Camera>().orthographicSize += 0.2f;
            temp = camera.transform.position;
            temp = Vector3.Lerp(temp,final,0.2f);
            camera.transform.position = temp;
            yield return new WaitForSeconds(0.01f);
        }
        camera.transform.position = final;
    }

    public void StartButton()
    {
        if(hasGameFinished)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            startButton.SetActive(false);
            settings.SetActive(false);
            developer.SetActive(false);
            hasGameStarted = true;
            scoreScript.highScoreText.gameObject.SetActive(false);
        }
        
    }
  
  

    public void Developer()
    {
        Application.OpenURL("https://www.linkedin.com/in/oguzhansecgel/");
    }

}
