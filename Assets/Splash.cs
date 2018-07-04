using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    public float secondsToSplash;
    public string sceneToLoad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(secondsToSplash>0){
            secondsToSplash -= Time.deltaTime;
        }else{
            StartCoroutine(LoadToScene());
        }
		
	}

    private IEnumerator LoadToScene(){
        SceneManager.LoadScene(1);
        yield return new WaitForSeconds(0.1f);
    }
}
