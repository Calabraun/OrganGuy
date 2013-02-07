#pragma strict

var countDownSeconds : int;
var warningSeconds : int;

var displaySeconds : int;
var displayMinutes : int;

private var startTime : int;
private var restSeconds : int;
private var roundedRestSeconds : int;
private var clockStarted : boolean = false;
 
public function StartClock() {

    startTime = Time.time;
    clockStarted = true;

    audio.pitch = 1;
    audio.Play();
}

public function ResetClock() {

    startTime = Time.time;
    clockStarted = true;
}

public function StopClock() {
    clockStarted = false;
    audio.Stop();
}

function OnGUI () {

    if (clockStarted) {
        var guiTime = Time.time - startTime;

        restSeconds = -(guiTime);
        roundedRestSeconds = Mathf.CeilToInt(restSeconds);

        displaySeconds = (roundedRestSeconds % 60) + countDownSeconds;
        displayMinutes = roundedRestSeconds / 60; 

        if (displaySeconds == countDownSeconds) { audio.pitch = 1; };
        if (displaySeconds == warningSeconds) { audio.pitch = 2; };

    }
 
}

