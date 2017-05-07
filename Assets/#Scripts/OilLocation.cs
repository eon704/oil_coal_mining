using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilLocation : MonoBehaviour {

	void Start() {
		oilTimeText.gameObject.SetActive (false);
		plasticTimeText.gameObject.SetActive (false);

		oilQuantityText.text = "Oil: " + oilQuantity.ToString () + " t";
		plasticQuantityText.text = "Plastic: " + plasticQuantity.ToString () + " t";

		plasticOilConsuptionText.text = "Consumption: " + plasticOilConsumption.ToString () + " oil";
	}

	// --------- OIL
	public int oilQuantity;
	public Text oilQuantityText;
	public int oilProduction;

	public int oilProduceTime;
	public int oilTimeLeft;
	public Text oilTimeText;

	bool oil_is_working = false;

	public void StartMinerWork() {
		if (oil_is_working) {
			return;
		}
		oilTimeText.gameObject.SetActive (true);
		oil_is_working = true;
		oilTimeLeft = oilProduceTime;
		oilTimeText.text = oilProduceTime.ToString () + " sec";
		Debug.Log ("Started miner work");
		InvokeRepeating ("MinerWork", 1f, 1f);
	}

	void MinerWork() {
		if (oilTimeLeft <= 1) {
			oilQuantity += oilProduction;
			oilQuantityText.text = "Oil: " + oilQuantity.ToString () + " t";

			oil_is_working = false;
			oilTimeText.gameObject.SetActive (false);
			Debug.Log ("Finished miner work");
			CancelInvoke ("MinerWork");
			return;
		}
		oilTimeLeft--;
		oilTimeText.text = oilTimeLeft.ToString () + " sec";
	}
		
	// ---------

	// --------- PLASTIC
	public int plasticQuantity;
	public Text plasticQuantityText;
	public int plasticProduction;

	public int plasticOilConsumption;
	public Text plasticOilConsuptionText;

	public int plasticProduceTime;
	public int plasticTimeLeft;
	public Text plasticTimeText;

	bool plastic_is_working = false;

	public void StartPlastic() {
		if (plastic_is_working) {
			return;
		}
		if (plasticOilConsumption > oilQuantity) {
			Debug.Log ("Insufficient oil");
			return;
		}

		plasticTimeText.gameObject.SetActive (true);
		plastic_is_working = true;
		plasticTimeLeft = plasticProduceTime;
		plasticTimeText.text = plasticTimeLeft.ToString () + " sec";

		oilQuantity -= plasticOilConsumption;
		oilQuantityText.text = "Oil: " + oilQuantity.ToString () + " t";

		Debug.Log ("Started plastic production");

		InvokeRepeating ("ProducePlastic", 1f, 1f);
	}

	void ProducePlastic() {
		if (plasticTimeLeft <= 1) {
			plasticQuantity += plasticProduction;
			plasticQuantityText.text = "Plastic: " + plasticQuantity.ToString () + " t";

			plastic_is_working = false;
			plasticTimeText.gameObject.SetActive (false);
			Debug.Log ("Finished Plastic production");
			CancelInvoke ("ProducePlastic");
			return;
		}
		plasticTimeLeft--;
		plasticTimeText.text = plasticTimeLeft.ToString () + " sec";
	}
	// ---------

	// --------- 


}
