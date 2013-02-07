using UnityEngine;
using System.Collections;

public class WellCreator : MonoBehaviour {
	
		
	public GameObject Well1;
	public GameObject Well2;
	public GameObject Well3; 
	
	public GameObject WellBottom;
	
	public GameObject DescentLight;
	
	public GameObject Skelly;
	
	public GameObject Eyeball;
	public GameObject Eyepatch;
	public GameObject Bandana;
	public GameObject Sword;
	public GameObject Heart;
	
	public GameObject spawnNextItem;
	public GameObject endGame;


	private GameObject[] _wellParts = new GameObject[100];
	
	private GameObject[] _pirateItems = new GameObject[5];
	private int _currentPirateItem;
	
	private int _wellIndicator, _wellDescentPosition;
	private bool _wellCreated;
	
	// Use this for initialization
	void Start () {
		
		endGame.SetActive(false);
		
		_wellParts[0] = (GameObject)GameObject.Instantiate(Well1, new Vector3(0, 0, 0), Well1.transform.rotation);
		_wellParts[1] = (GameObject)GameObject.Instantiate(Well2, new Vector3(0, -35, 0), Well2.transform.rotation);
		_wellParts[2] = (GameObject)GameObject.Instantiate(Well3, new Vector3(0, -70, 0), Well3.transform.rotation);
		_wellParts[3] = (GameObject)GameObject.Instantiate(Well1, new Vector3(0, -105, 0), Well1.transform.rotation);

		_wellIndicator = 3;
		_wellCreated = false;
		_wellDescentPosition = -105;
		
		_pirateItems[0] = Eyeball;
		_pirateItems[1] = Eyepatch;
		_pirateItems[2] = Bandana;
		_pirateItems[3] = Sword;
		
		_currentPirateItem = 0;
		spawnNextItem.SetActive(false);	 
		
		PopulateItems(_wellParts[1], _wellDescentPosition);

	}
	
	// Update is called once per frame
	void Update () {
	
		if (endGame.activeSelf == false) UpdateWell();
		
	//	_wellParts[0].transform.Rotate(Vector3.up * Time.deltaTime*10, Space.World);
	//	_wellParts[1].transform.Rotate(Vector3.down * Time.deltaTime*10, Space.World);
	//	_wellParts[2].transform.Rotate(Vector3.up * Time.deltaTime*10, Space.World);
	//	_wellParts[3].transform.Rotate(Vector3.down * Time.deltaTime*10, Space.World);
	
	}

	private void UpdateWell() {
		
		var _skellyDescentPosition = Skelly.transform.position.y;

		if ((_skellyDescentPosition - 40 < _wellDescentPosition))
		{
			_wellDescentPosition = _wellDescentPosition - 35;
			float randomNumber = Mathf.Round(Random.value*2);

			if (_currentPirateItem == 4) {			
				_wellParts[_wellIndicator] = (GameObject)GameObject.Instantiate(WellBottom, new Vector3(-3, _wellDescentPosition + 50, 3), WellBottom.transform.rotation);
				endGame.SetActive(true);
			}
			else
			{
				if (randomNumber == 0) { _wellParts[_wellIndicator] = (GameObject)GameObject.Instantiate(Well1, new Vector3(0, _wellDescentPosition, 0), Well1.transform.rotation); }
				if (randomNumber == 1) { _wellParts[_wellIndicator] = (GameObject)GameObject.Instantiate(Well2, new Vector3(0, _wellDescentPosition, 0), Well2.transform.rotation); }
				if (randomNumber == 2) { _wellParts[_wellIndicator] = (GameObject)GameObject.Instantiate(Well3, new Vector3(0, _wellDescentPosition, 0), Well3.transform.rotation); }			
			}

			_wellIndicator++;
			
			Destroy(_wellParts[_wellIndicator - 5]);
			
			PopulateItems(_wellParts[_wellIndicator], _wellDescentPosition);			
		}		
		
	}
	
	private void PopulateItems( GameObject currentWellSection, int spawnYLocation) {

		if (spawnNextItem.activeSelf)
		{
			_currentPirateItem++;	
			spawnNextItem.SetActive(false);
		}
		
		float randomNumber = Mathf.Round(Random.value*3);
		
		
		if (_currentPirateItem < 4) {
			if (randomNumber == 0)
			{
				var _pirateItem = (GameObject)GameObject.Instantiate(
				_pirateItems[_currentPirateItem], new Vector3(10, spawnYLocation+50, 0), _pirateItems[_currentPirateItem].transform.rotation); 
			
			}
		
			if (randomNumber == 1)
			{
				var _pirateItem = (GameObject)GameObject.Instantiate(
				_pirateItems[_currentPirateItem], new Vector3(-5, spawnYLocation+50, 20), _pirateItems[_currentPirateItem].transform.rotation); 
		
			}
		
			if (randomNumber == 2)
			{
				var _pirateItem = (GameObject)GameObject.Instantiate(
				_pirateItems[_currentPirateItem], new Vector3(10, spawnYLocation+50, 10), _pirateItems[_currentPirateItem].transform.rotation); 
			
			}
		
			if (randomNumber == 3)
			{
				var _pirateItem = (GameObject)GameObject.Instantiate(
				_pirateItems[_currentPirateItem], new Vector3(-15, spawnYLocation+50, 10), _pirateItems[_currentPirateItem].transform.rotation); 
			
			}
		}
		
		
			var _heart1 = (GameObject)GameObject.Instantiate(
			Heart, new Vector3(-5, spawnYLocation+50, 20), Heart.transform.rotation); 
			
			var _heart2 = (GameObject)GameObject.Instantiate(
			Heart, new Vector3(-15, spawnYLocation+50, 10), Heart.transform.rotation); 		
		
		
		
	}

}