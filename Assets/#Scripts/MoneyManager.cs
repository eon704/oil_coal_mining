using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyManager : MonoBehaviour {

	public int money;
	public int powerBatteries;

	public Text moneyText;
	public Text powerBatteriesText;

	// TODO: 1) remove electricity sell
	// 		 2) electricity consumption required only for updates
	//       3) autowork works always

	void Start() {
		UpdateUI ();
	}

	public void UpdateUI () {
		moneyText.text = money.ToString () + " $";
		powerBatteriesText.text = powerBatteries.ToString () + " batteries";
	}

	public bool Spend(int amount) {
		if (amount <= money) {
			money -= amount;
			UpdateUI ();
			return true;
		} else {
			Debug.Log ("Not enough money");
			return false;
		}
	}

	public void Fine(int amount) {
		money -= amount;
		UpdateUI ();
	}

	public void Earn(int amount) {
		money += amount;
		UpdateUI ();
	}
}
