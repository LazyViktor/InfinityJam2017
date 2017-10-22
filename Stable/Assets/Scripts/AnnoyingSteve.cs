using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnnoyingSteve : MonoBehaviour {

    public Canvas canvas;
    public Text MessageText;
    public Image Avatar;
    public Sprite[] popupPicture;
    public string[] random;
    public float frequenz;

    private Random rnd;
    private int ImageCount;
    private int RandomCount;
    private float _saveTimescale;

    private bool isActive = false;
    private bool isOpen = false;
	// Use this for initialization
	void Start ()
    {
        ImageCount = popupPicture.Length;
        RandomCount = random.Length;
        _saveTimescale = Time.timeScale;
        InvokeRepeating("RoleDices", 10f, frequenz);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        

        if (isActive && !isOpen)
        {            
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
            Avatar.GetComponent<Image>().sprite = popupPicture[Random.Range(0,ImageCount)];
            MessageText.GetComponent<Text>().text = random[Random.Range(0,RandomCount)];
            isOpen = true;
        }
		
	}

    public void RoleDices()
    {
        Debug.Log("Timescale: " + Time.timeScale);
        if (! isActive && Random.Range(0,1) < 0.13f)
        {
            isActive = true;
        }
    }

    public void ClosePopup()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = _saveTimescale;
        isActive = false;
        isOpen = false;
    }
}
