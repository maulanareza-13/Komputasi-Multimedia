using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerInventoryDisplay : MonoBehaviour
{
 public Text starText;
 public void OnChangeCarryingStar(bool carryingStar)
 {
 string starMessage = "Tidak Bawa Bintang :-(";
 if (carryingStar) starMessage = "Bawa Bintang :-)";
 starText.text = starMessage;
 }
}