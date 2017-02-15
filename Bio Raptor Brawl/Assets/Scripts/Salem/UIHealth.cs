using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHealth : MonoBehaviour {

    public Slider hSlider;
    public Slider hSliderPlayer2;
    public Characte2D_Chabona player1HealthRef;
    public Characte2D_Chabona player2HealthRef;




    void Start() {

        player1HealthRef = GameObject.Find("Player1").GetComponent<Characte2D_Chabona>();
        player2HealthRef = GameObject.Find("Player2").GetComponent<Characte2D_Chabona>();

    }
	void Update () {

        hSlider.value = player1HealthRef.curHealth;
        hSliderPlayer2.value = player2HealthRef.curHealth;
	}
}
