#pragma strict

var lantern: GameObject;
var eyeball: GameObject;
var eyepatch: GameObject;
var bandana: GameObject;
var sword: GameObject;
var heart: GameObject;
var WellTop: GameObject;
var descentLight: GameObject;
var endGame: GameObject;
var overGame: GameObject;

var clockStyle : GUIStyle;
var clockSmallStyle : GUIStyle;
var clockLargeStyle : GUIStyle;

var gameOverStyle : GUIStyle;

var countdownScript : CountdownScript;
var wellTop : GameObject;
var floor : GameObject;

var pirate1 : Texture2D;
var pirate2 : Texture2D;
var pirate3 : Texture2D;
var pirate4 : Texture2D;
var pirate5 : Texture2D;
var pirate6 : Texture2D;

var pirate : Texture2D;
var spawnNextItem : GameObject;
var heartCounter = 5;
var EndGUI : GameObject;
var gameOver : Texture2D;
var text : String;

function Start () {

    countdownScript = GameObject.FindWithTag("MainCamera").GetComponent("CountdownScript");

    wellTop = GameObject.FindWithTag("wellTop");
    floor = GameObject.FindWithTag("floor");

    lantern.SetActiveRecursively(false);
    eyeball.SetActiveRecursively(false);
    eyepatch.SetActiveRecursively(false);
    bandana.SetActiveRecursively(false);
    sword.SetActiveRecursively(false);

    pirate = pirate1;

    spawnNextItem.SetActive(false);

    heartCounter = 5;

    EndGUI.SetActiveRecursively(false);
}

function Update () {

}

function OnTriggerEnter (other : Collider) {

    if (other.gameObject.CompareTag ("lantern")) {
        Destroy (other.gameObject);
        lantern.SetActiveRecursively(true);
        pirate = pirate2;
        audio.Play();

        countdownScript.StartClock();       
        Destroy(wellTop);
        Destroy(floor);
    }
    if (other.gameObject.CompareTag ("eyeball")) {
        Destroy (other.gameObject);
        eyeball.SetActiveRecursively(true);
        pirate = pirate3;
        audio.Play();

        for (var _eyeball in GameObject.FindGameObjectsWithTag ("eyeball")){
            Destroy(_eyeball);
        }

        spawnNextItem.SetActive(true);
    }
    if (other.gameObject.CompareTag ("eyepatch")) {
        Destroy (other.gameObject);
        eyepatch.SetActiveRecursively(true);
        pirate = pirate4;
        audio.Play();

        for (var _eyepatch in GameObject.FindGameObjectsWithTag("eyepatch")){
            Destroy(_eyepatch);
        }

        spawnNextItem.SetActive(true);
    }
    if (other.gameObject.CompareTag ("bandana")) {
        Destroy (other.gameObject);
        bandana.SetActiveRecursively(true);
        pirate = pirate5;
        audio.Play();

        for (var _bandana in GameObject.FindGameObjectsWithTag ("bandana")){
            Destroy(_bandana);
        }

        spawnNextItem.SetActive(true);
    }
    if (other.gameObject.CompareTag ("sword")) {
        Destroy (other.gameObject);
        sword.SetActiveRecursively(true);
        pirate = pirate6;
        audio.Play();

        for (var _sword in GameObject.FindGameObjectsWithTag ("sword")){
            Destroy(_sword);
        }

        spawnNextItem.SetActive(true);
    }
    if (other.gameObject.CompareTag ("heart")) {
        Destroy (other.gameObject);
        audio.Play();

        countdownScript.ResetClock();
    }

    if (other.gameObject.CompareTag ("endHeart")) {
        Destroy (other.gameObject);
        audio.Play();
        Destroy(this);
        EndGUI.SetActiveRecursively(true);
    }
}

    function OnGUI () {
        var skellyRect;

        if (Screen.width <= 1024) {
            skellyRect = Rect(5, 5, 200, 350);
            clockStyle = clockSmallStyle;
        }
        else {
            skellyRect = Rect(10, 10, 400, 700);
            clockStyle = clockLargeStyle;
        }

        text = String.Format ("{1:0}", countdownScript.displayMinutes, countdownScript.displaySeconds); 

        GUI.backgroundColor = Color.clear;

        GUI.Box(skellyRect,pirate);
        GUI.Box(skellyRect,text.ToString(), clockStyle);

        GUI.backgroundColor = Color.black;

        if ((countdownScript.displaySeconds <= 0) || (WellTop && transform.position.y < -30)) {
            overGame.SetActive(true);
            countdownScript.StopClock();
            Destroy(descentLight);

            if (GUI.Button(Rect(0,0,Screen.width,Screen.height/2),"GAME OVER\nClick mouse to play again", gameOverStyle)){
                Application.LoadLevel(0);
            }
        }
    }
